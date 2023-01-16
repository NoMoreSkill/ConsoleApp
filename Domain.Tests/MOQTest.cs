using Autofac.Extras.Moq;
using Domain.Controllers;
using Domain.EndPoints;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Tests
{
    internal class MOQTest
    {
        [Test]
        public void Test()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IUserAccess>()
                    .Setup(x => x.GetUsers())
                    .Returns(GetUsers());
                var mockUserAccess = mock.Create<IUserAccess>();
                UserController ctr = new UserController(mockUserAccess);
                var users = ctr.GetUsers();

                Assert.True(users != null);
                Assert.AreEqual(2, users.Count());
            }
        }
        private List<User> GetUsers()
        {
            var users = new List<User>() {
            new User(){ID = 10008, Login = "Cambala", Email = "deepfish@hotmail.net", Name = "Jassy", CreationDate = new DateTime(2022,04,12)},
            new User(){ID = 10009, Login = "Nessy", Email = "deepestfish@hotmail.net", Name = "Loch", CreationDate = new DateTime(2022,04,13)}
            };
            return users;
        }
    }
}
