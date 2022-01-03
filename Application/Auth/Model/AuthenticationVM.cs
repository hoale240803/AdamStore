using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Application.Auth.Model
{
    public class AuthenticationVM
    {
        public string Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public List<string> Roles { get; set; }
        public string AccessToken { get; set; }

        [JsonIgnore]
        public string RefreshToken { get; set; }

        public DateTime RefreshTokenExpiration { get; set; }

        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }

    public class AuthenSuccessVM
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
    public class AuthenFailedVM
    {
        public string Message { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}