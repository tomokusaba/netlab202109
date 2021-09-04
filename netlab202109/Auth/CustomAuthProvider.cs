using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace netlab202109.Auth
{
    public class CustomAuthProvider : AuthenticationStateProvider
    {
        string userid;
        string pass;
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            await Task.Delay(1);
            if (string.IsNullOrWhiteSpace(userid))
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, userid) }, "apiauth")));
        }

        public void Login (string userid, string pass)
        {
            this.userid = userid;
            this.pass = pass;
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public void Logout ()
        {
            userid = string.Empty;
            pass = string.Empty;
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}
