using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Controllers;
using Domain.Models;

namespace Domain.Tests
{
    public class UserControllerTests
    {
        [Test]
        public void Test1()
        {
            User user = new User() {
            ID = 10000,
            Login = "Flippy",
            Email = "goddamn@hotmail.net",
            Name = "Jason",
            CreationDate = DateTime.Now
            };
            UserController userController = new UserController(new FileUserAccess());
            userController.AddUser(user.Login, user.Email, user.Name);
        }

    }
}
