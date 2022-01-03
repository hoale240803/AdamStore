using Application._Abstracts;
using Application.Auth.Model;
using Application.Auth.Token;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Application.Auth
{
    public class AuthServices : IAuthServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly ITokenServices _tokenServices;

        public AuthServices(IUnitOfWork unitOfWork,
            ITokenServices tokenServices, 
            UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _tokenServices = tokenServices;
            _userManager = userManager;
        }

        public Task<List<RefreshToken>> GetById(string id)
        {
            throw new NotImplementedException();
            //return Task.FromResult(_context.RefreshTokens.Where(x => x.UserId == id).ToList());
        }

        public async Task<AuthenticationVM> LoginAsync(LoginVM loginModel, string userId, string userRole)
        {
            // check existed email
            var authenticationModel = new AuthenticationVM();
            var currentUser = await _userManager.FindByEmailAsync(userId);
            if (currentUser == null)
            {
                authenticationModel.IsAuthenticated = false;
                authenticationModel.Message = $"No Accounts Registered with {loginModel.Username}.";

                return authenticationModel;
            }

            //check password
            var resultLogin = await _userManager.CheckPasswordAsync(currentUser, loginModel.Password);

            // generate token
            if (resultLogin)
            {
                // generate refresh token
                authenticationModel = GenerateRefreshToken(authenticationModel, loginModel.Username, userRole);
                currentUser.RefreshToken = authenticationModel.RefreshToken;
                currentUser.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);

                // update user
                _unitOfWork.Users.Update(currentUser);

                return authenticationModel;
            }

            authenticationModel.IsAuthenticated = false;
            authenticationModel.Message = $"Incorrect Credentials for user {loginModel.Username}.";
            authenticationModel.Success = false;

            return authenticationModel;
        }

        private AuthenticationVM GenerateRefreshToken(AuthenticationVM authenticationModel, string userName, string userRole)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userName),
                    new Claim(ClaimTypes.Role, userRole)
                };
            var accessToken = _tokenServices.GenerateAccessToken(claims);
            var refreshToken = _tokenServices.GenerateRefreshToken();

            //return login success model
            authenticationModel.AccessToken = accessToken;
            authenticationModel.RefreshToken = refreshToken;
            authenticationModel.IsAuthenticated = true;

            return authenticationModel;
        }

        public Task<AuthenticationVM> RefreshTokenAsync(string jwtToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RegisterAsync(RegisterVM registerModel)
        {
            throw new NotImplementedException();

        }

        public Task<bool> RevokeToken(string token)
        {
            throw new NotImplementedException();
        }
    }
}