using DAL.Actions.interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Actions.classs
{
    public class OrdersActions : IOrdersActions
    {
        GameShopDbContext _dbShop;

        public OrdersActions(GameShopDbContext dbShop)
        {
            this._dbShop = dbShop;
        }

        public List<OrdersTbl> GetAllOrders()
        {
            return _dbShop.OrdersTbls.ToList();
        }

        public void AddNewOrder(OrdersTbl o)
        {
            _dbShop.OrdersTbls.Add(o);
            _dbShop.SaveChanges();
        }

        public void UpdateOrder(int id, OrdersTbl o)
        {
            var orderToEdit = _dbShop.OrdersTbls.FirstOrDefault(x => x.OrderId == id);
            if (orderToEdit != null)
            {
                orderToEdit.OrderDate = o.OrderDate;
                orderToEdit.UserId = o.UserId;
                orderToEdit.FinalPrice = o.FinalPrice;
                _dbShop.SaveChanges();
            }
        }

        public void DeleteOrder(int id)
        {
            var orderToDelete = _dbShop.OrdersTbls.FirstOrDefault(x => x.OrderId == id);
            if (orderToDelete != null)
            {
                _dbShop.OrdersTbls.Remove(orderToDelete);
                _dbShop.SaveChanges();
            }
        }
    }
}
