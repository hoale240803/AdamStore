using Application._Abstracts;
using Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Users
{
    public interface IUserRepository : IRepository<AppUser>
    {
        AppUser NewUser(string userName, string email, string password, bool rememberMe);

        Task<AppUser> FindByNameAsync(string userName);


        Task<bool> CheckPasswordAsync(AppUser user, string password);


        Task<IList<string>> GetRolesAsync(AppUser user);


    }
}