using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netlab202109.Auth
{
    public class ListAuthService : IAuthService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        private List<(string loginid, string pass)> authList;

        public ListAuthService(AuthenticationStateProvider authenticationState)
        {
            _authenticationStateProvider = authenticationState;
            authList = new List<(string loginid, string pass)>();
            authList.Add(("hoge","fuga"));
            authList.Add(("foo", "bar"));
            authList.Add(("123", "456"));
            authList.Add(("id", "password"));
        }

        public LoginResult Login(LoginModel loginModel)
        {
            if (authList.Where(x => x.loginid == loginModel.UserID).Where(x => x.pass == loginModel.Password).Count() >= 1 )
            //if (loginModel.UserID == "scott" && loginModel.Password == "tiger")
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
