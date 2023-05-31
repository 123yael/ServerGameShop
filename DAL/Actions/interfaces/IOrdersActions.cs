using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Actions.interfaces
{
    public interface IOrdersActions
    {
        public List<OrdersTbl> GetAllOrders();

        public void AddNewOrder(OrdersTbl o);

        public void UpdateOrder(int id, OrdersTbl o);

        public void DeleteOrder(int id);

    }
}
