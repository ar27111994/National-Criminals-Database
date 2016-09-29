using AutoMapper;
using BusinessServices;
using BusinessServices.MapperConfig;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebClientContracts;

namespace ServicesTests
{
    [TestClass]
    public class CriminalServiceTest : IoCSupportedTest<AutoMapperModule>
    {
        private ICriminalService criminalService;
        private IMapper _mapper;

        [TestInitialize]
        public void Setup()
        {
            this.criminalService = Resolve<ICriminalService>();
            this._mapper = Resolve<IMapper>();
        }

        [TestMethod]
        public void CriminalSearchTest()
        {
            CriminalDTO c = new CriminalDTO()
            {
                Name = "asdfg",
                AgeMax = 59,
                AgeMin = 56,
                HieghtMax = 5.4,
                HieghtMin = 5.2,
                NationalityID = 2,
                Sex = 'M',
                WeightMax = 78,
                WeightMin = 76
            };
            string[] emails = new string[] { "ar27111994@gmail.com", "ar27111994@hotmail.com" };
            Assert.IsTrue(criminalService.SearchCriminals(c, emails));
        }

        [TestMethod]
        public void CriminalSearchTestFailed()
        {
            string[] emails = new string[] { "ar27111994@gmail.com", "ar27111994@hotmail.com" };
            CriminalDTO c = new CriminalDTO()
            {
                Name = "bhjjiik",
                AgeMax = 67,
                AgeMin = 65,
                HieghtMax = 5.9,
                HieghtMin = 5.7,
                NationalityID = 1,
                Sex = 'F',
                WeightMax = 70,
                WeightMin = 67
            };
            Assert.IsFalse(criminalService.SearchCriminals(c, emails));
        }

        [TestMethod]
        public void CriminalValidationTest()
        {
            CriminalDTO c = new CriminalDTO()
            {
                Name = "asdfg",
                AgeMax = 59,
                AgeMin = 56,
                HieghtMax = 5.4,
                HieghtMin = 5.2,
                NationalityID = 2,
                Sex = 'M',
                WeightMax = 78,
                WeightMin = 76
            };


            var results = Validation.Validate(c);
            Console.WriteLine(results);
            Assert.IsTrue(results.IsValid);
        }

        [TestMethod]
        public void CriminalValidationFailedTest()
        {
            CriminalDTO c = new CriminalDTO()
            {
                Name = null,
                AgeMax = 5999,
                AgeMin = 56321,
                HieghtMax = 0.4,
                HieghtMin = 0.2,
                NationalityID = 2,
                Sex = 'R',
                WeightMax = 787,
                WeightMin = -98
            };
            var results = Validation.Validate(c);
            Assert.IsFalse(results.IsValid);
        }


        [TestCleanup]
        public void TearDown()
        {
            criminalService = null;
            ShutdownIoC();
        }

    }
}
