using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shared.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        private readonly PasswordHasher<AppUser> hasher = new PasswordHasher<AppUser>();

        public AppUser(string firstName, string email, string password)
        {
            FirstName = firstName;
            Email = email;
            PasswordHash = password;
        }

        public AppUser()
        {

        }

        public AppUser(Guid id, string userName, string normalizedUserName,
            string email, string normalizedEmail,
            bool emailConfirmed,
            string passwordhashed,
            string securityStamp,
            string firstName,
            string lastName,
            DateTime dob)
        {
            Id = id;
            UserName = userName;

            NormalizedUserName = normalizedUserName;
            Email = email;

            NormalizedEmail = normalizedEmail;
            EmailConfirmed = emailConfirmed;

            PasswordHash = hasher.HashPassword(null, passwordhashed);
            SecurityStamp = securityStamp ?? string.Empty;

            FirstName = firstName;
            LastName = lastName;

            Dob = dob;
        }

        public List<Cart> Carts { get; set; }
        public CustomSetting CustomSetting { get; set; }
        public DateTime Dob { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public List<Order> Orders { get; set; }

        public List<Transaction> Transactions { get; set; }


        #region Login Model Refresh token
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        #endregion

        public bool ValidOnAdd()
        {
            return
                // Validate userName
                !string.IsNullOrEmpty(UserName)
                // Make sure email not null and correct email format
                && !string.IsNullOrEmpty(Email)
                && new EmailAddressAttribute().IsValid(Email);
        }
    }
}