using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using InventoryData;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;

namespace FinalAssignment.ViewModels
{
    class NewOrdersViewModel : Screen
    {
        
        public NewOrdersViewModel(IInventoryData helper)
        {
            IEnumerable<Order> gamma = helper.GetOrders();
            Orders = new ObservableCollection<Order>(gamma);
            OrderNumber = Orders.Count() + 1;

            _NewOrderItem = new ObservableCollection<OrderItem>();
            _NewOrder = new ObservableCollection<Order>();
            _NewOrder.Add(new Order() { OrderNumber = OrderNumber, DatePlaced = DateTime.Now, TotalCost = TotalCost });
            
            IEnumerable<Item> beta = helper.GetItems();
            Items = new ObservableCollection<Item>(beta);

            IEnumerable<User> kappa = helper.GetUsers();
            Users = new ObservableCollection<User>(kappa);
        }

        public int OrderNumber;
        
        private short _NewOrderItemQuantity;
        public short NewOrderItemQuantity
        {
            get
            {
                return _NewOrderItemQuantity;
            }
            set
            {
                _NewOrderItemQuantity = value;
            }
        }

        private decimal _TotalCost;
        public decimal TotalCost
        {
            get
            {
                return _TotalCost;
            }
            set
            {
                foreach(OrderItem inOrder in _NewOrderItem )
                    { value += inOrder.ItemCost * NewOrderItemQuantity; }
                _TotalCost = value;
            }
        }
        
        private int _OrderItemNumber;
        public int OrderItemNumber
        {
            get
            {
                return _OrderItemNumber++;
            }
            set
            {
                _OrderItemNumber = value;
            }
        }
        
        private ObservableCollection<Order> _NewOrder;
        public ObservableCollection<Order> NewOrder
        {
            get
            {
                return _NewOrder;
            }
            set
            {
                _NewOrder = value;
            }
        }

        private ObservableCollection<OrderItem> _NewOrderItem;
        public ObservableCollection<OrderItem> NewOrderItem
        {
            get
            {
                return _NewOrderItem;
            }
            set
            {
                _NewOrderItem = value;
            }
        }

        private ObservableCollection<Item> _Items;
        public ObservableCollection<Item> Items
        {
            get
            {
                return _Items;
            }
            set
            {
                _Items = value;
            }
        }

        private ObservableCollection<User> _Users;
        public ObservableCollection<User> Users
        {
            get
            {
                return _Users;
            }
            set
            {
                _Users = value;
            }
        }

        private User _SelectedUser;
        public User SelectedUser
        {
            get { return _SelectedUser; }
            set
            {
                _SelectedUser = value;
            }
        }

        private Item _SelectedItem;
        public Item SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                _SelectedItem = value;
            }
        }
        
        protected override void OnActivate()
        {
            base.OnActivate();
        }

        public IInventoryData DataManager { get; set; }
        public ObservableCollection<Order> Orders { get; private set; }

        public void SaveClick()
        {
            _NewOrderItem.Add(new OrderItem() { Item = SelectedItem, ItemCost = SelectedItem.Cost, ItemNumber = SelectedItem.ItemNumber, OrderNumber = OrderNumber, Quantity = NewOrderItemQuantity, OrderItemNumber = OrderItemNumber, Order = _NewOrder.ElementAt(0) });
            _NewOrder.First().OrderItems.Add(_NewOrderItem.ElementAt(_NewOrderItem.Count - 1));
            _NewOrder.First().TotalCost += _NewOrderItem.ElementAt(_NewOrderItem.Count - 1).ItemCost * _NewOrderItem.ElementAt(_NewOrderItem.Count - 1).Quantity;
            
            //Create an OrderItem with the attributes from outside
            //Use SaveOrderItem to a collection in DatabaseInteraction
            //Use GetOrderItems in viewmodel from a collection in Database Interaction for the listview
            //Update total cost
            //_Items.Add(new OrderItem() { OrderNumber = OrderNumber, });
            //  TotalCost =
        }

        public void SaveOrder()
        {
            _NewOrder.First().Purchaser = SelectedUser;

            foreach (Order element in _NewOrder)
            {
                DataManager.SaveOrder(element);
            }

            foreach (OrderItem element in _NewOrderItem)
            {
                DataManager.SaveOrderItem(OrderNumber, element);
            }

            MessageBox.Show("Order Saved");

            Refresh(); //trying to clear the fields.
            
        }

    }

}
