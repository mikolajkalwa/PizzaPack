using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using gui.ApiClient;
using gui.ApiClient.Models;
using Newtonsoft.Json;

namespace gui
{
    public partial class MainForm : Form
    {
        private readonly IPizzeriaApiClient _client;
        private readonly Menu _menu;
        private readonly ObservableCollection<DishOrder> _currentOrder = new ObservableCollection<DishOrder>();
        public MainForm(IPizzeriaApiClient client)
        {
            _client = client;
            _menu = _client.GetMenu();
            _currentOrder.CollectionChanged += OnCurrentOrderChanged;
            InitializeComponent();
        }

        private void ShowAvailableDishes()
        {
            dataGridViewMenu.DataSource = _menu.Dishes;

            dataGridViewMenu.Columns["DishIdentifier"].Visible = false;
            dataGridViewMenu.Columns["DishCategory"].Visible = false;

            dataGridViewMenu.Columns["DishName"].HeaderText = "Danie";
            dataGridViewMenu.Columns["DishPrice"].HeaderText = "Cena";

            dataGridViewMenu.Columns["DishPrice"].DefaultCellStyle.FormatProvider = new CultureInfo("PL");
            dataGridViewMenu.Columns["DishPrice"].DefaultCellStyle.Format = "c";

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ShowAvailableDishes();
        }

        private void buttonAddDishToOrder_Click(object sender, EventArgs e)
        {
            Dish selectedDish = _menu.Dishes.First(dish =>
                dish.DishIdentifier == dataGridViewMenu.SelectedRows[0].Cells["DishIdentifier"].Value.ToString());

            IList<Extras> availableExtras =
                _menu.Extras.Where(extras => extras.DishCategory == selectedDish.DishCategory).ToList();

            DishOrder dishOrder = new DishOrder
            {
                DishIdentifier = selectedDish.DishIdentifier,
                Quantity = Convert.ToInt32(numericUpDownDishQuantity.Value)
            };


            if (availableExtras.Any())
            {
                using (ChooseExtrasDialog chooseExtrasDialogForm = new ChooseExtrasDialog(availableExtras))
                {
                    chooseExtrasDialogForm.ShowDialog();
                    dishOrder.Extras = new List<string>();
                    IList<Extras> selectedExtras = chooseExtrasDialogForm.SelectedExtras;
                    if (selectedExtras != null)
                    {
                        foreach (var selectedExtra in selectedExtras)
                        {
                            dishOrder.Extras.Add(selectedExtra.ExtrasIdentifier);
                        }
                    }

                }
            }

            _currentOrder.Add(dishOrder);
            numericUpDownDishQuantity.Value = 1;

        }

        private void buttonSummarizeOrder_Click(object sender, EventArgs e)
        {
            using (SummarizeOrderForm summarizeOrderForm = new SummarizeOrderForm(_currentOrder, _menu, _client))
            {
                summarizeOrderForm.ShowDialog();

            }
        }

        private void buttonOrdersHistory_Click(object sender, EventArgs e)
        {
            using (OrdersHistoryForm ordersHistoryForm = new OrdersHistoryForm(_client))
            {
                ordersHistoryForm.ShowDialog();
            }
        }

        private decimal CalculateOrderValue()
        {
            decimal price = 0;
            foreach (var dishOrder in _currentOrder)
            {
                decimal extrasPrice = 0;
                var selectedDish = _menu.Dishes.First(dish =>
                    dish.DishIdentifier == dishOrder.DishIdentifier);
                if (dishOrder.Extras != null && dishOrder.Extras.Any())
                {
                    foreach (var dishOrderExtra in dishOrder.Extras)
                    {
                        var chosenExtras = _menu.Extras.First(extras => extras.ExtrasIdentifier == dishOrderExtra);
                        price += chosenExtras.ExtrasPrice;
                    }
                }

                price += (selectedDish.DishPrice + extrasPrice) * dishOrder.Quantity;

            }

            return price;
        }

        private void OnCurrentOrderChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            decimal orderValue = CalculateOrderValue();
            labelCurrentValue.Text = orderValue.ToString("c", new CultureInfo("PL"));
        }
    }
}
