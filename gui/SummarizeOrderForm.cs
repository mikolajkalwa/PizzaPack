using gui.ApiClient;
using gui.ApiClient.Models;
using gui.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace gui
{
    public partial class SummarizeOrderForm : Form
    {
        private readonly IPizzeriaApiClient _client;
        private readonly AppState _appState;
        private readonly OrderHelpers _orderHelpers;
        public SummarizeOrderForm(IPizzeriaApiClient client, AppState appState, OrderHelpers orderHelpers)
        {
            _appState = appState;
            _client = client;
            _orderHelpers = orderHelpers;
            _appState.DishesInOrder.CollectionChanged += OnCurrentOrderChanged;
            InitializeComponent();
        }

        private IBindingList GetOrderedDishesToDisplay()
        {
            IBindingList dataToDisplay = new BindingList<SummarizeOrderEntry>();
            foreach (var dishOrder in _appState.DishesInOrder)
            {
                decimal extrasPrice = 0;
                var orderedExtras = new StringBuilder();
                if (dishOrder.Extras != null && dishOrder.Extras.Any())
                {
                    foreach (var dishOrderExtra in dishOrder.Extras)
                    {
                        var extras = _orderHelpers.GetExtrasById(dishOrderExtra);
                        extrasPrice += extras.ExtrasPrice;
                        orderedExtras.AppendLine($"{extras.ExtrasName}");
                    }
                }

                var orderedDish = _orderHelpers.GetDishById(dishOrder.DishIdentifier);
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

        private void dataGridViewDishesToOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == dataGridViewDishesToOrder.NewRowIndex || e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == dataGridViewDishesToOrder.Columns["dataGridViewDeleteButton"].Index)
            {
                dataGridViewDishesToOrder.Rows.RemoveAt(e.RowIndex);
                _appState.DishesInOrder.RemoveAt(e.RowIndex);
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
                Dishes = _appState.DishesInOrder,
                Email = textBoxEmail.Text,
                Notes = richTextBoxOrderNotes.Text
            };

            _client.PlaceOrder(placeOrder);
            _appState.DishesInOrder.Clear();
            MessageBox.Show("Zamówienie zostało przyjęte!");
            Close();
        }

        private void SummarizeOrderForm_Load(object sender, EventArgs e)
        {
            decimal orderValue = _orderHelpers.CalculateOrderValue(_appState.DishesInOrder);
            labelTotalPrice.Text = orderValue.ToString("c", new CultureInfo("PL"));
            dataGridViewDishesToOrder.DataSource = GetOrderedDishesToDisplay();
            dataGridViewDishesToOrder.Columns["Extras"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dataGridViewDishesToOrder.Columns["DishName"].HeaderText = "Danie";
            dataGridViewDishesToOrder.Columns["Quantity"].HeaderText = "Ilość";
            dataGridViewDishesToOrder.Columns["Extras"].HeaderText = "Wybrane dodatki";
            dataGridViewDishesToOrder.Columns["TotalPrice"].HeaderText = "Cena";
            dataGridViewDishesToOrder.Columns["TotalPrice"].DefaultCellStyle.FormatProvider = new CultureInfo("PL");
            dataGridViewDishesToOrder.Columns["TotalPrice"].DefaultCellStyle.Format = "c";


            var deleteButtonColumn = new DataGridViewButtonColumn
            {
                Name = "dataGridViewDeleteButton",
                HeaderText = "Usuń z zamówienia",
                Text = "X",
                UseColumnTextForButtonValue = true
            };
            dataGridViewDishesToOrder.Columns.Add(deleteButtonColumn);
        }


        private void OnCurrentOrderChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            decimal orderValue = _orderHelpers.CalculateOrderValue(_appState.DishesInOrder);
            labelTotalPrice.Text = orderValue.ToString("c", new CultureInfo("PL"));
        }

    }
}
