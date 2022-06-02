using KefalosApi.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KefalosApi.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly AppSettings _appSettings;
        public AuthenticateService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        private List<User> users = new List<User>() { 
         new User
         {
             Id        = 1 , 
             FirstName = "Itai" ,
             LastName  = "Mhoks" ,
             Email     = "itai@admin.com" , 
             Password  = "password", 
             UserName  = "itai"
         }
        };
        public User Authenticate (string UserName, string Password)
        {
            var user = users.SingleOrDefault(x => x.UserName == UserName && x.Password == Password);

            // return null if user is found
            if (user == null)
                return null;

            //if useer if found
            var tokenhandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]{

                     new Claim(ClaimTypes.Name, user.Id.ToString()),
                     new Claim(ClaimTypes.Role, "Admin"),
                     new Claim(ClaimTypes.Version, "V3.1"),
                    }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };
            //now creating the token 
            var token = tokenhandler.CreateToken(tokenDescriptor);
            user.Token = tokenhandler.WriteToken(token);
            user.Password = null;

            return user;
        }
    }
}
