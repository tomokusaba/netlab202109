using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netlab202109.Auth
{
    public interface IAuthService
    {
        LoginResult Login(LoginModel loginModel);
        void Logout();
    }

    public class LoginModel
    {
        public string UserID { get; set; }
        public string Password { get; set; }
    }

    public class LoginResult
    {
        public bool IsSuccessful { get; set; }
        public Exception Error { get; set; }
        public string IDToken { get; set; }
    }
}
