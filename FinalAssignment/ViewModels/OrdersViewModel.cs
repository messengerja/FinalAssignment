using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using InventoryData;
using System.Collections.ObjectModel;

namespace FinalAssignment.ViewModels
{
    class OrdersViewModel : Screen
    {

        protected override void OnActivate()
        {
            base.OnActivate();
            
        }

        public OrdersViewModel(IInventoryData helper)
        {
            IEnumerable<Order> orders = helper.GetOrders();
            _Orders = new ObservableCollection<Order>(orders);
            //IEnumerable<OrderItem> orderItems = helper.GetOrderItems(_Orders.ElementAt(_SelectedOrderIndex).OrderNumber);
            //_OrderItems = new ObservableCollection<OrderItem>(orderItems);
        }

        private ObservableCollection<Order> _Orders;

        public ObservableCollection<Order> Orders
        {
            get
            {
                return _Orders;
            }
        }

        private ObservableCollection<OrderItem> _OrderItems;

        public ObservableCollection<OrderItem> OrderItems
        {
            get
            {
                return _OrderItems;
            }

            set
            {
                _OrderItems = value;
            }
        }

        private int _SelectedOrderIndex;

        public int SelectedOrderIndex
        {
            get
            {
                return _SelectedOrderIndex;
            }
            set
            {
                _SelectedOrderIndex = value;
            }
        }

        public void SelectionChanged(IInventoryData helper)
        {
            IEnumerable<OrderItem> orderItems = helper.GetOrderItems(_Orders.ElementAt(_SelectedOrderIndex).OrderNumber);
            _OrderItems = new ObservableCollection<OrderItem>(orderItems);
        }
        
    }
}
