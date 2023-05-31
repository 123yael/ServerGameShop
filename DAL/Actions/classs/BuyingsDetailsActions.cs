using DAL.Actions.interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Actions.classs
{
    public class BuyingsDetailsActions : IBuyingsDetailsActions
    {
        GameShopDbContext _dbShop;

        public BuyingsDetailsActions(GameShopDbContext dbShop)
        {
            this._dbShop = dbShop;
        }

        public List<BuyingsDetailsTbl> GetAllBuyingsDetails()
        {
            return _dbShop.BuyingsDetailsTbls.ToList();
        }

        public void AddNewBuyingsDetails(BuyingsDetailsTbl b)
        {
            _dbShop.BuyingsDetailsTbls.Add(b);
            _dbShop.SaveChanges();
        }

        public void UpdateBuyingsDetails(int id, BuyingsDetailsTbl b)
        {
            var buyingsDetailsToEdit = _dbShop.BuyingsDetailsTbls.FirstOrDefault(x => x.BuyingDetailesId == id);
            if (buyingsDetailsToEdit != null)
            {
                buyingsDetailsToEdit.ProductId = b.ProductId;
                buyingsDetailsToEdit.OrderId = b.OrderId;
                buyingsDetailsToEdit.Quantity = b.Quantity;
                buyingsDetailsToEdit.Price = b.Price;
                _dbShop.SaveChanges();
            }
        }

        public void DeleteBuyingsDetails(int id)
        {
            var buyingsDetailsToDelete = _dbShop.BuyingsDetailsTbls.FirstOrDefault(x => x.BuyingDetailesId == id);
            if (buyingsDetailsToDelete != null)
            {
                _dbShop.BuyingsDetailsTbls.Remove(buyingsDetailsToDelete);
                _dbShop.SaveChanges();
            }
        }
    }
}
