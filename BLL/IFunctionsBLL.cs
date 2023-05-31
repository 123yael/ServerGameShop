using DTO.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IFunctionsBLL
    {
        public List<ProductsDTO> GetAllProducts();

        public ProductsDTO? GetProductById(int id);

        public List<ProductsDTO>? GetProductsByCategoryId(int id);

        public List<ProductsDTO> AddNewProduct(ProductsDTO p);

        public List<ProductsDTO> UpdateProduct(int id, ProductsDTO p);

        public List<ProductsDTO> DeleteProduct(int id);

        public List<CategoriesDTO> GetAllCategories();

        public List<CategoriesDTO> AddNewCategory(CategoriesDTO c);

        public List<CategoriesDTO> UpdateCategory(int id, CategoriesDTO c);

        public List<CategoriesDTO> DeleteCategory(int id);

        public List<UsersDTO> GetAllUsers();

        public List<UsersDTO> AddNewUser(UsersDTO u);

        public List<UsersDTO> UpdateUser(int id, UsersDTO u);

        public UsersDTO? findUserByEmailAndPassword(string email, string password);

        public bool isManager(string email, string password);

        public List<int> CheckOrder(List<ProductToClintDTO> listProducts);

        public OrdersDTO? FinishOrder(int userId, List<ProductToClintDTO> listProducts);

        public List<OrdersDTO> GetAllOrdersByUserId(int userId);

    }
}
