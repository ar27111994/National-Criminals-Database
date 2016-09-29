using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using WebUIClient.Controllers;
using WebClients.Tests;
using AutoMapper;
using WebUIClient.UserServiceReference;
using WebUIClient.RoleServiceReference;
using WebUIClient.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

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
        public void RegisterValidationTest()
        {
            var u = new User();
            // Set some properties here
            u = new User() { Email = "ar27111994gmail.com", Password = "1234567891344556666vvvtttttttttttttttttttttttttttttttttttfffffffffffffffffhhhhhhhhhhhkkkkkkkppppppoooooo",
                Username = "ar27111994", LastLogin = DateTime.Now, RoleId = (byte)1 };

            var context = new ValidationContext(u, null, null);
            var results = new List<ValidationResult>();
            var isModelStateInValid = Validator.TryValidateObject(u, context, results, true);
            Assert.IsFalse(isModelStateInValid);
            u = new User() { Email = "ar27111994@gmail.com", Password = "123456789", Username = "ar27111994", LastLogin = DateTime.Now, RoleId = (byte)1 };
            context = new ValidationContext(u, null, null);
            results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(u, context, results, true);
            Assert.IsTrue(isModelStateValid);
        }

        [TestMethod]
        public void RegisterPost()
        {
            // Arrange
            AccountController controller = new AccountController(_user, _role, _mapper);

            // Act
            User u = new User() { Email = "ar27111994@gmail.com", Password = "123456789", Username = "ar27111994", LastLogin = DateTime.Now, RoleId = (byte)1 };
            RedirectToRouteResult result = controller.Register(u) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result.RouteValues["action"].Equals("Login") && result.RouteValues["controller"].Equals("Account"));
        }

        [TestMethod]
        public void Login()
        {
            // Arrange
            AccountController controller = new AccountController(_user, _role, _mapper);

            // Act
            ViewResult result = controller.Login() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void LoginValidationTest()
        {
            var l = new Login();
            // Set some properties here
            l = new Login()
            {
                Email = "ar27111994gmail.com",
                Password = "1234567891344556666vvvtttttttttttttttttttttttttttttttttttfffffffffffffffffhhhhhhhhhhhkkkkkkkppppppoooooo"
            };

            var context = new ValidationContext(l, null, null);
            var results = new List<ValidationResult>();
            var isModelStateInValid = Validator.TryValidateObject(l, context, results, true);
            Assert.IsFalse(isModelStateInValid);
            l = new Login() { Email = "ar27111994@gmail.com", Password = "123456789" };
            context = new ValidationContext(l, null, null);
            results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(l, context, results, true);
            Assert.IsTrue(isModelStateValid);
        }


        [TestMethod]
        public void LoginPost()
        {
            // Arrange
            AccountController controller = new AccountController(_user, _role, _mapper);

            // Act
            Login l = new Login() { Email = "ar27111994@gmail.com", Password = "123456789" };
            RedirectToRouteResult result = controller.Login(loginViewModel: l) as RedirectToRouteResult;
            Assert.IsNotNull(result, "Not a redirect result");
            Assert.IsFalse(result.Permanent); 
            // Assert
            Assert.AreEqual("Search", result.RouteValues["action"]);
            Assert.AreEqual("Criminals", result.RouteValues["controller"]);
        }

        [TestCleanup]
        public void TearDown()
        {
            _user = null;
            _role = null;
            ShutdownIoC();
        }

    }
}
