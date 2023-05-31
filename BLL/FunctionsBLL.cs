using AutoMapper;
using DTO.Repository;
using DAL.Models;
using System.Collections.Generic;
using DAL.Actions.interfaces;

namespace BLL
{
    public class FunctionsBLL : IFunctionsBLL
    {
        static IMapper _Mapper;

        static FunctionsBLL()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DTO.AutoMapper>();
            });
            _Mapper = config.CreateMapper();
        }

        IProductsActions _productsActions;
        ICategoriesActions _categoriesActions;
        IUsersActions _usersActions;
        IOrdersActions _ordersActions;
        IBuyingsDetailsActions _buyingsDetailsActions;
        public FunctionsBLL(IProductsActions productsActions, ICategoriesActions categoriesActions, IUsersActions usersActions, IOrdersActions ordersActions, IBuyingsDetailsActions buyingsDetailsActions)
        {
            _productsActions = productsActions;
            _categoriesActions = categoriesActions;
            _usersActions = usersActions;
            _ordersActions = ordersActions;
            _buyingsDetailsActions = buyingsDetailsActions;
        }

        #region Products

        // פונקציה שמחזירה את כל המוצרים
        public List<ProductsDTO> GetAllProducts()
        {
            var productsDTO = new List<ProductsDTO>();
            List<ProductsTbl> listProducts = _productsActions.GetAllProducts();
            foreach (var productTbl in listProducts)
                productsDTO.Add(_Mapper.Map<ProductsTbl, ProductsDTO>(productTbl));
            return productsDTO;
        }

        // צפיה במוצר לפי קוד מוצר
        public ProductsDTO? GetProductById(int id)
        {
            List<ProductsTbl> listProducts = _productsActions.GetAllProducts();
            var p = listProducts.FirstOrDefault(x => x.ProductId == id);
            if(p != null)
                return _Mapper.Map<ProductsTbl, ProductsDTO>(p);
            return null;
        }

        // צפיה במוצרים לפי קוד קטגוריה
        public List<ProductsDTO>? GetProductsByCategoryId(int id)
        {
            List<ProductsDTO> listProducts = GetAllProducts();
            var pList = listProducts.Where(x => x.CategoryId == id).ToList();
            if (pList != null)
                return pList;
            return null;
        }

        // פונקציה שמוסיפה מוצר חדש
        public List<ProductsDTO> AddNewProduct(ProductsDTO p)
        {
            _productsActions.AddNewProduct(_Mapper.Map<ProductsDTO, ProductsTbl>(p));
            return GetAllProducts();
        }

        // פונקציה לעדכון מוצר קיים
        public List<ProductsDTO> UpdateProduct(int id, ProductsDTO p)
        {
            _productsActions.UpdateProduct(id, _Mapper.Map<ProductsDTO, ProductsTbl>(p));
            return GetAllProducts();
        }

        // פונקציה למחיקת מוצר
        public List<ProductsDTO> DeleteProduct(int id)
        {
            _productsActions.DeleteProduct(id);
            return GetAllProducts();
        }
        #endregion

        #region Categories

        // פונקציה שמחזירה את כל הקטגוריות
        public List<CategoriesDTO> GetAllCategories()
        {
            var categotiesDTO = new List<CategoriesDTO>();
            List<CategoriesTbl> listCategories = _categoriesActions.GetAllCategories();
            foreach (var categoryTbl in listCategories)
                categotiesDTO.Add(_Mapper.Map<CategoriesTbl, CategoriesDTO>(categoryTbl));
            return categotiesDTO;
        }

        // פונקציה שמוסיפה קטגוריה חדשה
        public List<CategoriesDTO> AddNewCategory(CategoriesDTO c)
        {
            _categoriesActions.AddNewCategory(_Mapper.Map<CategoriesDTO, CategoriesTbl>(c));
            return GetAllCategories();
        }

        // פונקציה לעדכון קטגוריה קיימת
        public List<CategoriesDTO> UpdateCategory(int id, CategoriesDTO c)
        {
            _categoriesActions.UpdateCategory(id, _Mapper.Map<CategoriesDTO, CategoriesTbl>(c));
            return GetAllCategories();
        }

        // פונקציה למחיקת קטגוריה
        public List<CategoriesDTO> DeleteCategory(int id)
        {
            _categoriesActions.DeleteCategory(id);
            return GetAllCategories();
        }
        #endregion

        #region Users

        // צפיה בכל המשתמשים
        public List<UsersDTO> GetAllUsers()
        {
            List<UsersDTO> newListUsers = new List<UsersDTO>();
            List<UsersTbl> oldListUsers = _usersActions.GetAllUsers();
            foreach (var user in oldListUsers)
                newListUsers.Add(_Mapper.Map<UsersTbl, UsersDTO>(user));
            return newListUsers;
        }

        // הוספת משתמש חדש למערכת
        public List<UsersDTO> AddNewUser(UsersDTO u)
        {
            _usersActions.AddNewUser(_Mapper.Map<UsersDTO, UsersTbl>(u));
            return GetAllUsers();
        }

        // עריכת פרטי משתמש
        public List<UsersDTO> UpdateUser(int id, UsersDTO u)
        {
            _usersActions.UpdateUser(id, _Mapper.Map<UsersDTO, UsersTbl>(u));
            return GetAllUsers();
        }

        // מציאת משתמש על פי מייל וסיסמה
        public UsersDTO? findUserByEmailAndPassword(string email, string password)
        {
            var user = _usersActions.GetAllUsers().FirstOrDefault(x => x.UserPassword.Equals(password) && x.UserEmail.Equals(email));
            if (user != null)
                return _Mapper.Map<UsersTbl, UsersDTO>(user);
            return null;
        }

        // בדיקה האם מדובר במנהל
        public bool isManager(string email, string password)
        {
            return (email == "malkin.yaeli@gmail.com" && password == "214100174");
        }
        #endregion

        #region Cart

        // פונקציה שבודקת כמה חסר במלאי לכל מוצר אם בכלל
        public List<int> CheckOrder(List<ProductToClintDTO> listProducts)
        {
            List<int> rezult = new List<int>();
            foreach (var product in listProducts)
            {
                var qis = GetProductById(product.ProductId)?.QuantityInStock;
                if (product.Count > qis)
                    rezult.Add(product.Count - (int)qis);
                else
                    rezult.Add(0);
            }
            return rezult;
        }

        // פונקציה לסיום קניה באופן מוחלט
        public OrdersDTO? FinishOrder(int userId, List<ProductToClintDTO> listProducts)
        {
            // בדיקה אולי בכל אופן המשתמש הצליח לשלוח עגלה ריקה
            if (listProducts.Count == 0)
                return null;
            OrdersDTO newOrder = new OrdersDTO();
            newOrder.OrderDate = DateTime.Now;
            newOrder.UserId = userId;
            decimal sumPrice = 0;
            foreach (var product in listProducts)
                sumPrice += product.FinalPrice;
            newOrder.FinalPrice = sumPrice;
            OrdersTbl newO = _Mapper.Map<OrdersDTO, OrdersTbl>(newOrder);
            _ordersActions.AddNewOrder(newO);
            foreach (var product in listProducts)
            {
                var prod = GetProductById(product.ProductId);
                if (prod != null)
                {
                    prod.QuantityInStock -= product.Count;
                    UpdateProduct(prod.ProductId, prod);
                }
                BuyingsDetailsDTO newbuyingsDetails = new BuyingsDetailsDTO();
                newbuyingsDetails.ProductId = product.ProductId;
                newbuyingsDetails.OrderId = newO.OrderId;
                newbuyingsDetails.Quantity = product.Count;
                newbuyingsDetails.Price = product.FinalPrice;
                _buyingsDetailsActions.AddNewBuyingsDetails(_Mapper.Map<BuyingsDetailsDTO, BuyingsDetailsTbl>(newbuyingsDetails));
            }
            return _Mapper.Map<OrdersTbl, OrdersDTO>(newO);
        }

        #endregion

        #region Orders

        // פונקציה שמחזירה רשימה של קניות לפי קוד לקוח
        public List<OrdersDTO> GetAllOrdersByUserId(int userId)
        {
            List<OrdersTbl> temp = _ordersActions.GetAllOrders().Where(o => o.UserId == userId).ToList();
            List<OrdersDTO> newList = new List<OrdersDTO>();
            foreach (var order in temp)
                newList.Add(_Mapper.Map<OrdersTbl, OrdersDTO>(order));
            return newList;
        }

        #endregion

    }
}