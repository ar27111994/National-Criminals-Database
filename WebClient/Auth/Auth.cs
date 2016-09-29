using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace WebUIClient.Auth
{
    public class Auth : IAuth
    {
        public void DoAuth(string userName, bool remember)
        {
            FormsAuthentication.SetAuthCookie(userName, remember);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}