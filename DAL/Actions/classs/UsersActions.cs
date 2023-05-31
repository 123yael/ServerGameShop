using DAL.Actions.interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Actions.classs
{
    public class UsersActions : IUsersActions
    {
        GameShopDbContext _dbShop;

        public UsersActions(GameShopDbContext dbShop)
        {
            this._dbShop = dbShop;
        }

        public List<UsersTbl> GetAllUsers()
        {
            return _dbShop.UsersTbls.ToList();
        }

        public void AddNewUser(UsersTbl u)
        {
            _dbShop.UsersTbls.Add(u);
            _dbShop.SaveChanges();
        }

        public void UpdateUser(int id, UsersTbl u)
        {
            var userToEdit = _dbShop.UsersTbls.FirstOrDefault(x => x.UserId == id);
            if (userToEdit != null)
            {
                userToEdit.FirstName = u.FirstName;
                userToEdit.LastName = u.LastName;
                userToEdit.UserAddress = u.UserAddress;
                userToEdit.UserPhone = u.UserPhone;
                userToEdit.UserPassword = u.UserPassword;
                userToEdit.UserEmail = u.UserEmail;
                _dbShop.SaveChanges();
            }
        }

        public void DeleteUser(int id)
        {
            var userToDelete = _dbShop.UsersTbls.FirstOrDefault(x => x.UserId == id);
            if (userToDelete != null)
            {
                _dbShop.UsersTbls.Remove(userToDelete);
                _dbShop.SaveChanges();
            }
        }
    }
}
