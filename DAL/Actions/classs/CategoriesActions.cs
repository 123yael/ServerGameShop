using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Actions.interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Actions.classs
{
    public class CategoriesActions : ICategoriesActions
    {
        GameShopDbContext _dbShop;

        public CategoriesActions(GameShopDbContext dbShop)
        {
            this._dbShop = dbShop;
        }

        public List<CategoriesTbl> GetAllCategories()
        {
            return _dbShop.CategoriesTbls.Where(c => !c.IsDelete).ToList();
        }

        public void AddNewCategory(CategoriesTbl c)
        {
            _dbShop.CategoriesTbls.Add(c);
            _dbShop.SaveChanges();
        }

        public void UpdateCategory(int id, CategoriesTbl c)
        {
            var Category = _dbShop.CategoriesTbls.FirstOrDefault(x => x.CategoryId == id);
            if (Category != null)
            {
                Category.CategoryName = c.CategoryName;
                Category.IsDelete = c.IsDelete;
                _dbShop.SaveChanges();
            }
        }

        public void DeleteCategory(int id)
        {
            var categoryToDelete = _dbShop.CategoriesTbls.FirstOrDefault(x => x.CategoryId == id);
            if (categoryToDelete != null)
            {
                categoryToDelete.IsDelete = true;
                _dbShop.SaveChanges();
            }
        }
    }
}
