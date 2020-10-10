using gui.ApiClient;
using gui.ApiClient.Models;
using gui.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace gui
{
    public partial class SummarizeOrderForm : Form
    {
        private readonly Menu _menu;
        private readonly IList<DishOrder> _dishesToOrder;
        private readonly IBindingList _dishesToOrderDisplay;
        private readonly IPizzeriaApiClient _client;
        public SummarizeOrderForm(IList<DishOrder> dishesToOrder, Menu menu, IPizzeriaApiClient client)
        {
            _menu = menu;
            _dishesToOrder = dishesToOrder;
            _dishesToOrderDisplay = GetOrderedDishesToDisplay();
            _client = client;
            InitializeComponent();
        }

        private IBindingList GetOrderedDishesToDisplay()
        {
            IBindingList dataToDisplay = new BindingList<SummarizeOrderEntry>();
            foreach (var dishOrder in _dishesToOrder)
            {
                decimal extrasPrice = 0;
                var orderedExtras = new StringBuilder();
                if (dishOrder.Extras != null && dishOrder.Extras.Any())
                {
                    foreach (var dishOrderExtra in dishOrder.Extras)
                    {
                        var extras = _menu.Extras.First(extra => extra.ExtrasIdentifier == dishOrderExtra);
                        extrasPrice += extras.ExtrasPrice;
                        orderedExtras.AppendLine($"{extras.ExtrasName}");
                    }
                }

                var orderedDish = _menu.Dishes.First(dish => dish.DishIdentifier == dishOrder.DishIdentifier);
                decimal price = (orderedDish.DishPrice + extrasPrice) * dishOrder.Quantity;
                dataToDisplay.Add(new SummarizeOrderEntry
                {
                    DishName = orderedDish.DishName,
                    Quantity = dishOrder.Quantity,
                    Extras = orderedExtras.ToString(),
                    TotalPrice = price
                });
            }

            return dataToDisplay;
        }

        private void SummarizeOrderForm_Load(object sender, EventArgs e)
        {
            dataGridViewDishesToOrder.DataSource = _dishesToOrderDisplay;
            dataGridViewDishesToOrder.Columns["Extras"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dataGridViewDishesToOrder.Columns["DishName"].HeaderText = "Danie";
            dataGridViewDishesToOrder.Columns["Quantity"].HeaderText = "Ilość";
            dataGridViewDishesToOrder.Columns["Extras"].HeaderText = "Wybrane dodatki";
            dataGridViewDishesToOrder.Columns["TotalPrice"].HeaderText = "Cena";
            dataGridViewDishesToOrder.Columns["TotalPrice"].DefaultCellStyle.FormatProvider = new CultureInfo("PL");
            dataGridViewDishesToOrder.Columns["TotalPrice"].DefaultCellStyle.Format = "c";


            var deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.Name = "dataGridViewDeleteButton";
            deleteButtonColumn.HeaderText = "Usuń z zamówienia";
            deleteButtonColumn.Text = "X";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            dataGridViewDishesToOrder.Columns.Add(deleteButtonColumn);


        }

        private void dataGridViewDishesToOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == dataGridViewDishesToOrder.NewRowIndex || e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == dataGridViewDishesToOrder.Columns["dataGridViewDeleteButton"].Index)
            {
                dataGridViewDishesToOrder.Rows.RemoveAt(e.RowIndex);
                _dishesToOrder.RemoveAt(e.RowIndex);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonPlaceOrder_Click(object sender, EventArgs e)
        {
            var placeOrder = new PlaceOrder
            {
                Dishes = _dishesToOrder,
                Email = textBoxEmail.Text,
                Notes = richTextBoxOrderNotes.Text
            };

            _client.PlaceOrder(placeOrder);
            MessageBox.Show("Zamówienie zostało przyjęte!");
            Close();
        }
    }
}
