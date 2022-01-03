using Microsoft.AspNetCore.Identity;
using System;

namespace Data.Entities
{
    public class AppRole : IdentityRole<Guid>
    {
        public string Description { get; set; }
    }
}