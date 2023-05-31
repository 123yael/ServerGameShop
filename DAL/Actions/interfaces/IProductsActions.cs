using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Actions.interfaces
{
    public interface IProductsActions
    {
        public List<ProductsTbl> GetAllProducts();

        public void AddNewProduct(ProductsTbl p);

        public void UpdateProduct(int id, ProductsTbl p);

        public void DeleteProduct(int id);

    }
}
