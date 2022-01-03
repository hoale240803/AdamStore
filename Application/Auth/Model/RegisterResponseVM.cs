using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Application.Auth.Model
{
    public class RegisterResponseVM
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public IEnumerable<IdentityError> ListMessage { get; set; }
        public string Token { get; set; }
    }
}