using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Actions.interfaces
{
    public interface IUsersActions
    {

        public List<UsersTbl> GetAllUsers();

        public void AddNewUser(UsersTbl u);

        public void UpdateUser(int id, UsersTbl u);

        public void DeleteUser(int id);

    }
}
