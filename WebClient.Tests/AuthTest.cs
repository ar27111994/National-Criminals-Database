using System;
using WebUIClient.Auth;

namespace WebClient.Tests
{
    public class AuthTest : IAuth
    {
        public void DoAuth(string userName, bool remember)
        {
            Console.WriteLine("Logged In!");
        }

        public void SignOut()
        {
            Console.WriteLine("Logged Out!");
        }
    }
}