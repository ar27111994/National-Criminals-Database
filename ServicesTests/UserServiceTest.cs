using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessServices;
using BusinessServices.MapperConfig;
using WebClientContracts;
using Persistence;
using AutoMapper;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace ServicesTests
{
    [TestClass]
    public class UserServiceTest : IoCSupportedTest<AutoMapperModule>
    {
        private IUserService userService;
        private IMapper _mapper;

        [TestInitialize]
        public void Setup()
        {
            this.userService = Resolve<IUserService>();
            this._mapper = Resolve<IMapper>();
        }
        [TestMethod]
        public void RegistrationTest()
        {
            UserDTO u = new UserDTO() { Email = "ar27111994@gmail.com", Password = "123456789", Username = "ar27111994", LastLogin = DateTime.Now, RoleId = 1 };
            userService.Register(u);
        }

        [TestMethod]
        public void RegistrationValidationTest()
        {
            var u = new UserDTO()
            {
                Email = "ar27111994gmail.com",
                Password = "1234567891344556666vvvtttttttttttttttttttttttttttttttttttfffffffffffffffffhhhhhhhhhhhkkkkkkkppppppoooooo",
                Username = "ar27111994",
                LastLogin = DateTime.Now,
                RoleId = (byte)1
            };
            var results = Validation.Validate(u);
            Assert.IsFalse(results.IsValid);
            u = new UserDTO() { Email = "ar27111994@gmail.com", Password = "123456789", Username = "ar27111994", LastLogin = DateTime.Now, RoleId = (byte)1 };
            results = Validation.Validate(u);
            Assert.IsTrue(results.IsValid);
        }

        [TestMethod]
        public void LoginTest()
        {
            bool Login = userService.Authenticate("123456789", "ar27111994@gmail.com");
            Assert.IsTrue(Login);
        }

        [TestMethod]
        public void MapperTest()
        {
            UserDTO u = new UserDTO() { Email = "ar27111994@gmail.com", Password = "123456789", Username = "ar27111994", LastLogin = DateTime.Now, RoleId = 1 };
            User regUser = _mapper.Map<User>(u);
        }

        [TestCleanup]
        public void TearDown()
        {
            userService = null;
            ShutdownIoC();
        }
    }
}
