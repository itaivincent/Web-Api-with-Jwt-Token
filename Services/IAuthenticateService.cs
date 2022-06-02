using KefalosApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KefalosApi.Services
{
    public interface IAuthenticateService
    {
        User Authenticate(string UserName, string Password);
    }
}
