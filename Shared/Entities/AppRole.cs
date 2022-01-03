using Microsoft.AspNetCore.Identity;
using System;

namespace Shared.Entities
{
    public class AppRole : IdentityRole<Guid>
    {
        public string Description { get; set; }
    }
}