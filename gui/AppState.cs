using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using gui.ApiClient.Models;

namespace gui
{
    public class AppState
    {
        public ObservableCollection<DishOrder> DishesInOrder { get; set; }
        public Menu Menu { get; set; }
    }
}
