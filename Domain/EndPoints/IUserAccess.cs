using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.EndPoints
{
    public interface IUserAccess
    {
        void AddUser(User user);
        void UpdUser(User user);
        void DelUser(User user);
        List<User> GetUsers();
    }
}
