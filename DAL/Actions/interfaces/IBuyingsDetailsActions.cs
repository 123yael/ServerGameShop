using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Actions.interfaces
{
    public interface IBuyingsDetailsActions
    {
        public List<BuyingsDetailsTbl> GetAllBuyingsDetails();

        public void AddNewBuyingsDetails(BuyingsDetailsTbl b);

        public void UpdateBuyingsDetails(int id, BuyingsDetailsTbl b);

        public void DeleteBuyingsDetails(int id);

    }
}
