using Application.Auth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Auth
{
    public interface IAuthServices
    {
        Task<bool> RegisterAsync(RegisterVM registerModel);

        Task<AuthenticationVM> LoginAsync(LoginVM loginModel, string userId, string userRole);


        Task<AuthenticationVM> RefreshTokenAsync(string jwtToken);

        Task<bool> RevokeToken(string token);

        Task<List<RefreshToken>> GetById(string id);
    }
}
