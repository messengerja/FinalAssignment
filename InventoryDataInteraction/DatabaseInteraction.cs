using InventoryData;
using InventoryDataMapping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDataInteraction
{
	public class DatabaseInteraction : IInventoryData, IUserRepository
	{
		public DatabaseInteraction()
		{
		}

		public IEnumerable<Order> GetOrders()
		{
			using(var db = new InventoryContext())
			{
				return (from order in db.Orders.Include("OrderItems")
											   .Include("OrderItems.Item")
											   .Include("Purchaser")
						select order).ToList();
			}
		}

		public IEnumerable<Item> GetItems()
		{
            List<Item> list = new List<Item>();
           
            list.Add(new Item() { ItemNumber = 100, Name = "Item1", Cost = 50.00M, QuantityOnHand = 5 });
            list.Add(new Item() { ItemNumber = 101, Name = "Item2", Cost = 60.00M, QuantityOnHand = 12 });
            list.Add(new Item() { ItemNumber = 102, Name = "Item3", Cost = 73.00M, QuantityOnHand = 7 });
            list.Add(new Item() { ItemNumber = 103, Name = "Item4", Cost = 24.00M, QuantityOnHand = 13 });
            list.Add(new Item() { ItemNumber = 104, Name = "Item5", Cost = 13.00M, QuantityOnHand = 2 });
            IEnumerable<Item> i = list;
            return i;



            //using (var db = new InventoryContext())
            //{
            //	return (from item in db.Items
            //			select item).ToList();
            //}
        }

        public IEnumerable<OrderItem> GetOrderItems(int orderNumber)
		{
			using (var db = new InventoryContext())
			{
				return (from orderItem in db.OrderItems
						where orderItem.OrderNumber == orderNumber
						select orderItem).ToList();
			}
		}

		public bool SaveOrder(Order order)
		{

            return true; //not using this ...YET
			//if (order == null)
			//	return false;

			//try
			//{
			//	using (var db = new InventoryContext())
			//	{
			//		db.Orders.Add(order);
			//		db.SaveChanges();
			//	}
			//	return true;
			//}
			//catch (Exception e)
			//{
			//	return false;
			//}
		}

		public bool SaveItem(Item item)
		{
            return true; //not using this ...YET

            //if (item == null)
            //	return false;

            //try
            //{
            //	using (var db = new InventoryContext())
            //	{
            //		db.Items.Add(item);
            //		db.SaveChanges();
            //	}
            //	return true;
            //}
            //catch(Exception e)
            //{
            //	return false;
            //}
        }

		public bool SaveOrderItem(int orderNumber, OrderItem orderItem)
		{
            return true; //not using this ...YET

   //         if (orderItem == null)
			//	return false;

			//try
			//{
			//	using (var db = new InventoryContext())
			//	{
			//		var order = (from o in db.Orders
			//					 where o.OrderNumber == orderNumber
			//					 select o).SingleOrDefault();

			//		if (order == null)
			//			return false;

			//		order.OrderItems.Add(orderItem);
			//		db.OrderItems.Add(orderItem);
			//		db.SaveChanges();
			//	}

			//	return true;
			//}
			//catch(Exception e)
			//{
			//	return false;
			//}
		}

		public IEnumerable<User> GetUsers()
		{
			using (var db = new InventoryContext())
			{
				return (from user in db.Users
						select user).ToList();
			}
		}

		public bool SaveUser(User user)
		{
            return true; //not using this ...YET

   //         if (user == null)
			//	return false;

			//try
			//{
			//	using (var db = new InventoryContext())
			//	{
			//		db.Users.Add(user);
			//		db.SaveChanges();
			//	}
			//	return true;
			//}
			//catch (Exception e)
			//{
			//	return false;
			//}
		}

		public IEnumerable<Order> GetUserOrders(int userId)
		{
			using (var db = new InventoryContext())
			{
				return (from u in db.UserOrders
						where u.UserId == userId
						select u.Order).ToList();
			}
		}


		public Task<IEnumerable<Order>> GetOrdersAsync()
		{
			var factory = new TaskFactory<IEnumerable<Order>>();
			return factory.StartNew(() =>
			{
				return this.GetOrders();
			});
		}

		public Task<IEnumerable<Item>> GetItemsAsync()
		{
			var factory = new TaskFactory<IEnumerable<Item>>();
			return factory.StartNew(() =>
			{
				return GetItems();
			});
		}

		public Task<IEnumerable<OrderItem>> GetOrderItemsAsync(int orderNumber)
		{
			var factory = new TaskFactory<IEnumerable<OrderItem>>();
			return factory.StartNew(() =>
			{
				return GetOrderItems(orderNumber);
			});
		}

		public Task<bool> SaveOrderAsync(Order order)
		{
			var factory = new TaskFactory<bool>();
			return factory.StartNew(() =>
			{
				return SaveOrder(order);
			});
		}

		public Task<bool> SaveItemAsync(Item item)
		{
			var factory = new TaskFactory<bool>();
			return factory.StartNew(() =>
			{
				return SaveItem(item);
			});
		}

		public Task<bool> SaveOrderItemAsync(int orderNumber, OrderItem orderItem)
		{
			var factory = new TaskFactory<bool>();
			return factory.StartNew(() =>
			{
				return SaveOrderItem(orderNumber, orderItem);
			});
		}

		public Task<IEnumerable<User>> GetUsersAsync()
		{
			return new TaskFactory<IEnumerable<User>>().StartNew(this.GetUsers);
		}

		public Task<bool> SaveUserAsync(User user)
		{
			return new TaskFactory<bool>().StartNew(() => this.SaveUser(user));
		}

		public Task<IEnumerable<Order>> GetUserOrdersAsync(int userId)
		{
			return new TaskFactory<IEnumerable<Order>>().StartNew(() => this.GetUserOrders(userId));
		}
	}
}
