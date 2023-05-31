using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Actions.interfaces
{
    public interface ICategoriesActions
    {
        public List<CategoriesTbl> GetAllCategories();

        public void AddNewCategory(CategoriesTbl c);

        public void UpdateCategory(int id, CategoriesTbl c);

        public void DeleteCategory(int id);
    }
}
