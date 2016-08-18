using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using InventoryData;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace FinalAssignment.ViewModels
{
    class NewOrdersViewModel : Screen
    {


        public NewOrdersViewModel(IInventoryData helper)
        {

            _NewOrderItem = new ObservableCollection<OrderItem>();
            _NewOrder = new ObservableCollection<Order>();
            _NewOrder.Add(new Order() { OrderNumber = OrderNumber, DatePlaced = DateTime.Now, Purchaser = alpha, TotalCost = TotalCost });

            IEnumerable<Item> beta = helper.GetItems();
            Items = new ObservableCollection<Item>(beta);
        }

        int OrderNumber = 42;
        User alpha = new User() { Name = "Wallace" };
        
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
        
        public void SaveClick()
        {
            _NewOrderItem.Add(new OrderItem() { Item = SelectedItem, ItemCost = SelectedItem.Cost, ItemNumber = SelectedItem.ItemNumber, OrderNumber = OrderNumber, Quantity = NewOrderItemQuantity, OrderItemNumber = OrderItemNumber, Order = _NewOrder.ElementAt(0) });
            
            //Create an OrderItem with the attributes from outside
            //Use SaveOrderItem to a collection in DatabaseInteraction
            //Use GetOrderItems in viewmodel from a collection in Database Interaction for the listview
            //Update total cost
            //_Items.Add(new OrderItem() { OrderNumber = OrderNumber, });
              //  TotalCost =
        }

    }

}
