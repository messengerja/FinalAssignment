using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using System.Collections.ObjectModel;

namespace FinalAssignment.ViewModels
{
    class OrdersViewModel : Screen
    {
        public OrdersViewModel()
        {
            _Orders = new ObservableCollection<Order>();
            _Orders.Add(new Order() { OrderNumber = "1", DatePlaced = "01/01/1999", OrderTotal = "52.25", Purchaser = "Purchaser 1" });
            _Orders.Add(new Order() { OrderNumber = "2", DatePlaced = "02/05/2002", OrderTotal = "28.50", Purchaser = "Purchaser 2" });
            _Orders.Add(new Order() { OrderNumber = "3", DatePlaced = "06/06/2005", OrderTotal = "97.40", Purchaser = "Purchaser 3" });
            _Orders.Add(new Order() { OrderNumber = "4", DatePlaced = "11/11/2011", OrderTotal = "111.11", Purchaser = "Purchaser 4" });

        }

        private ObservableCollection<Order> _Orders;

        public ObservableCollection<Order> Orders
        {
            get
            {
                return _Orders;
            }
        }
        
    }

    public class Order
    {
        public string OrderNumber { get; set; }
        public string DatePlaced { get; set; }
        public string Purchaser { get; set; }
        public string OrderTotal { get; set; }
    }
}
