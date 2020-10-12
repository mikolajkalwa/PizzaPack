using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using gui.ApiClient;
using gui.ApiClient.Models;
using gui.Models;

namespace gui
{
    public partial class OrdersHistoryForm : Form
    {
        private readonly IPizzeriaApiClient _client;
        private readonly OrderHelpers _orderHelpers;

        public OrdersHistoryForm(IPizzeriaApiClient client, OrderHelpers orderHelpers)
        {
            _client = client;
            _orderHelpers = orderHelpers;
            InitializeComponent();
        }

        private void OrdersHistoryForm_Load(object sender, EventArgs e)
        {
            var orders = _client.GetOrdersHistory();
            listBoxOrders.DataSource = orders;
            listBoxOrders.DisplayMember = "OrderIdentifier";
        }

        private string GetOrderedExtrasToDisplay(IList<OrderedExtras> extras)
        {
            if (extras == null)
            {
                return string.Empty;
            }

            var orderedExtras = new StringBuilder();
            foreach (var dishOrderExtra in extras)
            {
                orderedExtras.AppendLine(dishOrderExtra.Name);
            }

            return orderedExtras.ToString();
        }

        private decimal GetOrderedExtrasPrice(IList<OrderedExtras> extras)
        {
            if (extras == null)
            {
                return 0;
            }

            decimal orderedExtrasPrice = 0;

            foreach (var dishOrderExtra in extras)
            {
                orderedExtrasPrice += dishOrderExtra.Price;
            }

            return orderedExtrasPrice;

        }

        private IBindingList GetDataToDisplayInOrderedDishes(IList<OrderedDish> orderedDishes)
        {
            var summarizeOrderEntries = new BindingList<SummarizeOrderEntry>();
            foreach (var orderedDish in orderedDishes)
            {
                summarizeOrderEntries.Add(new SummarizeOrderEntry
                {
                    DishName = orderedDish.Name,
                    Quantity = orderedDish.Quantity,
                    TotalPrice = orderedDish.Price + GetOrderedExtrasPrice(orderedDish.Extras),
                    Extras = GetOrderedExtrasToDisplay(orderedDish.Extras)
                });

            }
            return summarizeOrderEntries;
        }

        private void listBoxOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            var order = (Order)listBoxOrders.SelectedItems[0];
            var result = _orderHelpers.TryConvertObjectIdToDateTime(order.OrderIdentifier, out DateTime date);

            textBoxOrderDate.Text = result ? date.ToLocalTime().ToString() : order.OrderIdentifier;
            richTextBoxNotes.Text = order.Notes;
            textBoxTotalPrice.Text = order.TotalPrice.ToString("C", new CultureInfo("PL"));
            textBoxEmail.Text = order.Email;

            textBoxOrderidentifier.Text = order.OrderIdentifier;

            dataGridViewOrderedDishes.DataSource = GetDataToDisplayInOrderedDishes(order.Dishes);
            dataGridViewOrderedDishes.Columns["Extras"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dataGridViewOrderedDishes.Columns["DishName"].HeaderText = "Danie";
            dataGridViewOrderedDishes.Columns["Quantity"].HeaderText = "Ilość";
            dataGridViewOrderedDishes.Columns["Extras"].HeaderText = "Wybrane dodatki";
            dataGridViewOrderedDishes.Columns["TotalPrice"].HeaderText = "Cena";
            dataGridViewOrderedDishes.Columns["TotalPrice"].DefaultCellStyle.FormatProvider = new CultureInfo("PL");
            dataGridViewOrderedDishes.Columns["TotalPrice"].DefaultCellStyle.Format = "c";
        }
    }
}
