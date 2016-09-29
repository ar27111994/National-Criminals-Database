using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUIClient.Auth
{
    public interface IAuth
    {
        void DoAuth(string userName, bool remember);
        void SignOut();
    }
}
