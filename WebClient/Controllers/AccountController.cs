﻿using AutoMapper;
using System;
using System.Web.Mvc;
using WebClientContracts;
using WebUIClient.ViewModels;
using WebUIClient.UserServiceReference;
using System.ServiceModel;
using System.Web.Security;
using WebUIClient.RoleServiceReference;
using WebUIClient.Auth;

namespace WebUIClient.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;
        private IAuth _auth;
        private IUserService UserService { get; set; }
        private IRoleService RoleService { get; set; }
        public AccountController(IUserService usrsvc, IRoleService rolesvc, IMapper mapper, IAuth auth)
        {
            _mapper = mapper;
            UserService = usrsvc;
            RoleService = rolesvc;
            _auth = auth;
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            try
            {
                ViewData["Roles"] = new SelectList(RoleService.GetRoles(),"Id","RoleName");
                return View();
            }
            catch (FaultException<WebUIClient.RoleServiceReference.ValidationFault> ex)
            {
                // Extract the Detail node from the Fault Exception. 
                // This details is the
                // ValidationFault class
                WebUIClient.RoleServiceReference.ValidationFault fault = ex.Detail;
                string alert = "";
                foreach (WebUIClient.RoleServiceReference.ValidationDetail validationResult in fault.Details)
                {
                    alert = String.Concat(string.Format("Message={0} Key={1} Tag={2}",
                        validationResult.Message, validationResult.Key,
                                validationResult.Tag));
                }

                return JavaScript("<script>alert(\"" + alert + "\")</script>");

            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserDTO regUser = _mapper.Map<UserDTO>(user);
                    UserService.Register(regUser);
                    Login login = new Login() { Email = regUser.Email, Password = regUser.Password };
                    return Login(login);
                }
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

                return JavaScript("<script>alert(\"" + alert + "\")</script>");

            }
        }
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login loginViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool Authenticated = UserService.Authenticate(loginViewModel.Password, loginViewModel.Email);
                    if (Authenticated)
                    {
                        _auth.DoAuth(loginViewModel.Email, true);
                        return RedirectToAction("Search", "Criminals");
                    }
                }
                return View(loginViewModel);
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

                return JavaScript("<script>alert(\"" + alert + "\")</script>");

            }
        }

        [Authorize]
        public ActionResult Logout()
        {
            _auth.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}