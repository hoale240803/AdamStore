using AdamStore.Infrastructure.EF;
using Application.Users;
using Microsoft.AspNetCore.Identity;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdamStore.Infrastructure.Repositories
{
    public class UserRepository : Repository<AppUser>, IUserRepository
    {
        private readonly AdamStoreDbContext dbContext;

        private readonly UserManager<AppUser> _userManager;
        public UserRepository(AdamStoreDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> CheckPasswordAsync(AppUser user, string password)
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> FindByNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync(AppUser user)
        {
            throw new NotImplementedException();
        }

        public AppUser NewUser(string userName, string email, string password, bool rememberMe)
        {
            var user = new AppUser(userName, email, password);
            if (user.ValidOnAdd())
            {
                this.Add(user);
                return user;
            }
            else
                throw new Exception("User invalid");
        }
    }
}