using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessServices;
using BusinessServices.MapperConfig;
using WebClientContracts;
using Persistence;
using AutoMapper;

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
            UserDTO u = new UserDTO() { Email="ar274@g.com", Password="156789", Username= "ar294", LastLogin=DateTime.Now, RoleId=(byte)1 };
            userService.Register(u);
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
