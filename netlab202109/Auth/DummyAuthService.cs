using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netlab202109.Auth
{
    public class DummyAuthService : IAuthService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public DummyAuthService(AuthenticationStateProvider authenticationState)
        {
            _authenticationStateProvider = authenticationState;
        }

        public  LoginResult Login(LoginModel loginModel)
        {
            if (loginModel.UserID == "scott" && loginModel.Password == "tiger")
            {
                var res = new LoginResult()
                {
                    IsSuccessful = true,
                    IDToken = "hoge"
                };
                ((CustomAuthProvider)_authenticationStateProvider).Login(loginModel.UserID, loginModel.Password);
                return res;
            } 
            else
            {
                return new LoginResult()
                {
                    IsSuccessful = false,
                    Error = new AccessViolationException("NotAuthrized")
                };
            }
        }

        public void Logout()
        {
            ((CustomAuthProvider)_authenticationStateProvider).Logout();
        }
    }
}
