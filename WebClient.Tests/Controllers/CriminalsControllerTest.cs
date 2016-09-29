using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebClients.Tests;
using AutoMapper;
using WebUIClient.CriminalServiceReference;
using WebUIClient.NationalityServiceReference;
using WebUIClient.Controllers;
using System.Web.Mvc;
using WebUIClient.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebClient.Tests.Controllers
{
    [TestClass]
    public class CriminalsControllerTest : IoCSupportedTest
    {
        private IMapper _mapper;
        private ICriminalService _criminal;
        private INationalityService _nationality;

        [TestInitialize]
        public void Setup()
        {
            this._mapper = Resolve<IMapper>();
            this._criminal = Resolve<ICriminalService>();
            this._nationality = Resolve<INationalityService>();
        }

        [TestMethod]
        public void SearchTest()
        {
            // Arrange
            CriminalsController controller = new CriminalsController(_nationality, _criminal, _mapper);

            // Act
            ViewResult result = controller.Search() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CriminalVeiwModelValidationTest()
        {
            var c=new Criminal()
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
            var context = new ValidationContext(c, null, null);
            var results = new List<ValidationResult>();
            var isModelStateInValid = Validator.TryValidateObject(c, context, results, true);
            Assert.IsFalse(isModelStateInValid);
        }

        [TestMethod]
        public void CriminalVeiwModelValidationFailedTest()
        {
            var c = new Criminal()
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
            var context = new ValidationContext(c, null, null);
            var results = new List<ValidationResult>();
            var isModelStateInValid = Validator.TryValidateObject(c, context, results, true);
            Assert.IsFalse(isModelStateInValid);
        }

        [TestMethod]
        public void SearchPost()
        {
            var c = new Criminal()
            {
                Name = "asdfg",
                AgeMax = 59,
                AgeMin = 56,
                HieghtMax = 5.4,
                HieghtMin = 5.2,
                NationalityID = 2,
                gender = Criminal.Gender.Male,
                Sex = (char)Criminal.Gender.Male,
                WeightMax = 78,
                WeightMin = 76
            };

            string[] emails = new string[] { "ar27111994@gmail.com", "ar27111994@hotmail.com" };

            CriminalsController controller = new CriminalsController(_nationality, _criminal, _mapper);

            // Act
            JavaScriptResult result = controller.Search(c, emails) as JavaScriptResult;
            Assert.AreEqual(result.Script, "<script>alert(\"Success! Results are bieng emailed to you.\");</script>");
        }

        [TestMethod]
        public void SearchPostFailed()
        {
            string[] emails = new string[] { "ar27111994@gmail.com", "ar27111994@hotmail.com" };

            CriminalsController controller = new CriminalsController(_nationality, _criminal, _mapper);

            var c = new Criminal()
            {
                Name = "bhjjiik",
                AgeMax = 67,
                AgeMin = 65,
                HieghtMax = 5.9,
                HieghtMin = 5.7,
                NationalityID = 1,
                gender = Criminal.Gender.Female,
                Sex = 'F',
                WeightMax = 70,
                WeightMin = 67
            };
            JavaScriptResult result = controller.Search(c, emails) as JavaScriptResult;

            Assert.AreEqual(result.Script, "<script>alert(\"Sorry! No Matching Records Found.\");</script>");

        }

        [TestCleanup]
        public void TearDown()
        {
            _criminal = null;
            _nationality = null;
            ShutdownIoC();
        }

    }
}
