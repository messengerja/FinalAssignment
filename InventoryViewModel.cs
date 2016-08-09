using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using System.Collections.ObjectModel;

namespace FinalAssignment.ViewModels
{
    class InventoryViewModel : Screen
    {
        /// <summary>
        /// adds dummy data to the observable collection
        /// </summary>
        public InventoryViewModel()
        {           
            _Inventory = new ObservableCollection<Item>();
            _Inventory.Add(new Item() { ItemNumber = "100", Name = "Item1", Cost = "50.00", Quantity = "5" });
            _Inventory.Add(new Item() { ItemNumber = "101", Name = "Item2", Cost = "60.00", Quantity = "12" });
            _Inventory.Add(new Item() { ItemNumber = "102", Name = "Item3", Cost = "73.00", Quantity = "7" });
            _Inventory.Add(new Item() { ItemNumber = "103", Name = "Item4", Cost = "24.00", Quantity = "13" });
            _Inventory.Add(new Item() { ItemNumber = "104", Name = "Item5", Cost = "13.00", Quantity = "2" });
        }
        
        private ObservableCollection<Item> _Inventory;
        /// <summary>
        /// gets the Observable collection of Inventory Items
        /// </summary>
        public ObservableCollection<Item> Inventory
        {
            get
            {
                return _Inventory;
            }
        }
        
    }
    //created ItemModel to hold dummy data
   public class Item
    {
        public string ItemNumber { get; set; }
        public string Name { get; set; }
        public string Cost { get; set; }
        public string Quantity { get; set; }
    }
    //assignment 11
    //o InventoryView/InventoryViewModel
    //     This view should show all available items in the database(faked for now) 
    //     You’ll have a data grid that shows the Item Number, Name, Cost, and Quantity on Hand for each item in the collection(see Figure 3) 
    //     You view model should have an Items collection for holding the retrieved items
    //     You should populate your Items property with some fake data for now


    //put in OnActivate with caliburn override
    //create an itemscollection for holding the dummy data
    //on activate is going to call a method in the iInventory
}
