using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using WebUIClient.CriminalServiceReference;
using WebUIClient.NationalityServiceReference;
using WebClientContracts;
using WebUIClient.ViewModels;

namespace WebUIClient.Controllers
{
    [Authorize]
    public class CriminalsController : Controller
    {
        private INationalityService NationalityService { get; set; }
        private ICriminalService CriminalService { get; set; }
        private readonly IMapper _mapper;

        public CriminalsController(INationalityService natsvc, ICriminalService crmnlsvc, IMapper mapper)
        {
            _mapper = mapper;
            NationalityService = natsvc;
            CriminalService = crmnlsvc;
        }

        public ActionResult Search()
        {
            try
            {
                ViewData["Nationalities"] = new SelectList(NationalityService.GetNationalities(),"Id","NationalityName");
                return View();
            }
            catch (FaultException<WebUIClient.NationalityServiceReference.ValidationFault> ex)
            {
                // Extract the Detail node from the Fault Exception. 
                // This details is the
                // ValidationFault class
                WebUIClient.NationalityServiceReference.ValidationFault fault = ex.Detail;
                string alert = "";
                foreach (WebUIClient.NationalityServiceReference.ValidationDetail validationResult in fault.Details)
                {
                    alert = String.Concat(string.Format("Message={0} Key={1} Tag={2}",
                        validationResult.Message, validationResult.Key,
                                validationResult.Tag));
                }

                return JavaScript("<script>alert(\"" + alert + "\");</script>");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(WebUIClient.ViewModels.Criminal criminalViewModel, string[] emails)
        {
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        criminalViewModel.Sex = (char)criminalViewModel.gender;
                        CriminalDTO criteria = _mapper.Map<CriminalDTO>(criminalViewModel);
                        if (CriminalService.SearchCriminals(criteria, emails))
                        {
                            return JavaScript("<script>alert(\"Success! Results are bieng emailed to you.\");</script>");
                        }
                        else
                        {
                            return JavaScript("<script>alert(\"Sorry! No Matching Records Found.\");</script>");
                        }
                    }
                    ViewData["Nationalities"] = new SelectList(NationalityService.GetNationalities(), "Id", "NationalityName");
                    return View();
                }
                catch (FaultException<WebUIClient.UserServiceReference.ValidationFault> ex)
                {
                    // Extract the Detail node from the Fault Exception. 
                    // This details is the
                    // ValidationFault class
                    WebUIClient.UserServiceReference.ValidationFault fault = ex.Detail;
                    string alert = "";
                    foreach (WebUIClient.UserServiceReference.ValidationDetail validationResult in fault.Details)
                    {
                        alert = String.Concat(string.Format("Message={0} Key={1} Tag={2}",
                            validationResult.Message, validationResult.Key,
                                    validationResult.Tag));
                    }

                    return JavaScript("<script>alert(\"" + alert + "\");</script>");

                }

            }
        }
    }
}