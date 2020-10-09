using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using gui.ApiClient;
using Newtonsoft.Json;

namespace gui
{
    public partial class MainForm : Form
    {
        private readonly IRestClient _apiRestClient;
        public MainForm(IRestClient apiRestClient)
        {
            _apiRestClient = apiRestClient;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var menu = _apiRestClient.GetMenu();
            dataGridViewMenu.DataSource = menu.Dishes;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
