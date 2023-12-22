using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;
using System.Net.Http.Headers;
using System.Text;
using RestfulWebApiEx.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using RestfulWebApi.DataLayer;
namespace RestfulWebApiEx.Handler

{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly DataBaseContext _DBContext;
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> option, ILoggerFactory logger,
        UrlEncoder encoder, ISystemClock clock, DataBaseContext dBContext) : base(option, logger, encoder, clock)
        {
            _DBContext = dBContext;
        }
        protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("No header found");
            Logger.LogError("Girdi1");
            var _haedervalue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            Logger.LogError("Girdi2");
            Logger.LogError("_haedervalue : " + _haedervalue);
            var bytes = Convert.FromBase64String(_haedervalue.Parameter!=null?_haedervalue.Parameter:string.Empty);
            string credentials = Encoding.UTF8.GetString(bytes);
            if (!string.IsNullOrEmpty(credentials))
            {
                Logger.LogError("Girdi");

                string[] array = credentials.Split(":");
                string username = array[0];
                string password = array[1];
                 var user=await this._DBContext.Users.FirstOrDefaultAsync(item=>item.Username==username && item.Password==password);
                 if(user==null)
                   return AuthenticateResult.Fail("UnAuthorized");

           // Generate Ticket
           var claim=new[]{new Claim(ClaimTypes.Name,username)};
           var identity=new ClaimsIdentity(claim,Scheme.Name);
           var principal=new ClaimsPrincipal(identity);
           var ticket=new AuthenticationTicket(principal,Scheme.Name);

                return AuthenticateResult.Success(ticket);
            }else{
                return AuthenticateResult.Fail("UnAuthorized");

            }
        }
    }
}