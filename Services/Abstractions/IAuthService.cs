using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Dto;

namespace WebProject.Services.Abstractions
{
    public interface IAuthService
    {
        string VerifyCredentials(AuthDto auth);
    }
}