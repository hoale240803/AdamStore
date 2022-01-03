using System;

namespace Shared.Entities
{
    public class CustomSetting
    {
        public string Id { get; set; }
        public string ThemeColor { get; set; }
        public string Font { get; set; }

        public Guid UserId { get; set; }

        public AppUser AppUser { get; set; }
    }
}