using gui.ApiClient;
using gui.ApiClient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace gui
{
    public partial class MainForm : Form
    {
        private readonly AppState _appState;
        private readonly OrderHelpers _orderHelpers;
        private readonly IPizzeriaApiClient _client;
        public MainForm(IPizzeriaApiClient client, AppState appState, OrderHelpers orderHelpers)
        {
            _appState = appState;
            _client = client;
            _orderHelpers = orderHelpers;
            _appState.Menu = client.GetMenu();
            _appState.DishesInOrder = new ObservableCollection<DishOrder>();
            _appState.DishesInOrder.CollectionChanged += OnCurrentOrderChanged;
            InitializeComponent();
        }

        private void ShowAvailableDishes()
        {
            dataGridViewMenu.DataSource = _appState.Menu.Dishes;

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
            Dish selectedDish = _orderHelpers.GetDishById(dataGridViewMenu.SelectedRows[0].Cells["DishIdentifier"].Value.ToString());
            IList<Extras> availableExtras = _orderHelpers.GetAvailableExtrasForCategory(selectedDish.DishCategory);

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

            _appState.DishesInOrder.Add(dishOrder);
            numericUpDownDishQuantity.Value = 1;

        }

        private void buttonSummarizeOrder_Click(object sender, EventArgs e)
        {
            using (SummarizeOrderForm summarizeOrderForm = new SummarizeOrderForm(_client, _appState, _orderHelpers))
            {
                summarizeOrderForm.ShowDialog();

            }
        }

        private void buttonOrdersHistory_Click(object sender, EventArgs e)
        {
            using (OrdersHistoryForm ordersHistoryForm = new OrdersHistoryForm(_client, _orderHelpers))
            {
                ordersHistoryForm.ShowDialog();
            }
        }

        private void OnCurrentOrderChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            decimal orderValue = _orderHelpers.CalculateOrderValue(_appState.DishesInOrder);
            labelCurrentValue.Text = orderValue.ToString("c", new CultureInfo("PL"));
        }
    }
}
