using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Domain.EndPoints;
using Domain.Models;

namespace Domain.Controllers
{
    public class UserController
    {
        private readonly IUserAccess _userAccess;
        public UserController(IUserAccess userAccess)
        {
            _userAccess = userAccess;
        }
        public void AddUser(string login, string email, string name)
        {
            User user = new User()
            {
                Login = login,
                Email = email,
                Name = name
            };
            _userAccess.AddUser(user);
        }
        public void UpdUser(int ID, string login, string email, string name)
        {
            User user = new User()
            {
                ID = ID,
                Login = login,
                Email = email,
                Name = name
            };
            _userAccess.AddUser(user);
        }
        public void DelUser(int ID)
        {
            User user = new User()
            {
                ID = ID
            };
            _userAccess.AddUser(user);
        }
        public List<User> GetUsers()
        {
            return _userAccess.GetUsers();
        }
    }
}
