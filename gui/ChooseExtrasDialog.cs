using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using gui.ApiClient.Models;

namespace gui
{
    public partial class ChooseExtrasDialog : Form
    {
        private readonly IList<Extras> _availableExtras;

        public IList<Extras> SelectedExtras { get; set; }

        public ChooseExtrasDialog(IList<Extras> availableExtras)
        {
            _availableExtras = availableExtras;
            InitializeComponent();
        }

        private void ChooseExtras_Load(object sender, EventArgs e)
        {
            checkedListBoxAvailableExtras.DataSource = _availableExtras;
        }

        private void buttonCancelExtrasOrder_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonConfirmExtras_Click(object sender, EventArgs e)
        {
            SelectedExtras = checkedListBoxAvailableExtras.CheckedItems.OfType<Extras>().ToList();
            Close();
        }
    }
}
