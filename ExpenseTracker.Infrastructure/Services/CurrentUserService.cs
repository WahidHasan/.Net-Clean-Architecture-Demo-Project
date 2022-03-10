using ExpenseTracker.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Infrastructure.Services
{
    public class CurrentUserService: ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            //UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            //UserName = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);
            //Email = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Email);
            UserId = "abc";
            Email = "abc@test.com";
        }
        public string UserId { get; }

        public string UserName { get; }

        public string Email { get; }
    }
}
