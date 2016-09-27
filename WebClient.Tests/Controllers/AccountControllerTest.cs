using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using WebUIClient.Controllers;
using WebClients.Tests;
using AutoMapper;
using WebUIClient.UserServiceReference;
using WebUIClient.RoleServiceReference;
using WebUIClient.ViewModels;

namespace WebClient.Tests.Controllers
{
    [TestClass]
    public class AccountControllerTest : IoCSupportedTest
    {
        private IMapper _mapper;
        private IUserService _user;
        private IRoleService _role;

        [TestInitialize]
        public void Setup()
        {
            this._mapper = Resolve<IMapper>();
            this._user = Resolve<IUserService>();
            this._role = Resolve<IRoleService>();
        }

        [TestMethod]
        public void Register()
        {
            // Arrange
            AccountController controller = new AccountController(_user, _role, _mapper);

            // Act
            ViewResult result = controller.Register() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void RegisterPost()
        {
            // Arrange
            AccountController controller = new AccountController(_user, _role, _mapper);

            // Act
            User u = new User() { Email = "ar27111994@gmail.com", Password = "123456789", Username = "ar27111994", LastLogin = DateTime.Now, RoleId = (byte)1 };
            ViewResult result = controller.Register(u) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
