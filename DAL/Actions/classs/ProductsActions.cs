using DAL.Actions.interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Actions.classs
{
    public class ProductsActions : IProductsActions
    {
        GameShopDbContext _dbShop;

        public ProductsActions(GameShopDbContext dbShop)
        {
            this._dbShop = dbShop;
        }

        public List<ProductsTbl> GetAllProducts()
        {
            return _dbShop.ProductsTbls.Include(x => x.Category).Where(p => !p.IsDelete).ToList();
        }

        public void AddNewProduct(ProductsTbl p)
        {
            _dbShop.ProductsTbls.Add(p);
            _dbShop.SaveChanges();
        }

        public void UpdateProduct(int id, ProductsTbl p)
        {
            var productToEdit = _dbShop.ProductsTbls.FirstOrDefault(x => x.ProductId == id);
            if (productToEdit != null)
            {
                productToEdit.ProductName = p.ProductName;
                productToEdit.ProductPrice = p.ProductPrice;
                productToEdit.ProductPic = p.ProductPic;
                productToEdit.QuantityInStock = p.QuantityInStock;
                productToEdit.IsDelete = p.IsDelete;
                productToEdit.CategoryId = p.CategoryId;
                _dbShop.SaveChanges();
            }
        }

        public void DeleteProduct(int id)
        {
            var productToDelete = _dbShop.ProductsTbls.FirstOrDefault(x => x.ProductId == id);
            if (productToDelete != null)
            {
                productToDelete.IsDelete = true;
                _dbShop.SaveChanges();
            }
        }
    }
}
