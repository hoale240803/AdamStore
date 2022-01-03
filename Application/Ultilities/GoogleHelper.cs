using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;

namespace Application.Ultilities
{
    public class GoogleHelper
    {
        private static string ClientId { get; set; }
        private static string ClientSecret { get; set; }
        private static string ApplicationName { get; set; }

        private static readonly string[] Scopes = {
            CalendarService.Scope.Calendar,
            CalendarService.Scope.CalendarEvents
        };

        public static CalendarService GetGoogleCalendarServiveAuthorization(string accessToken, string refreshToken)
        {
            var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets { ClientId = ClientId, ClientSecret = ClientSecret },
                Scopes = Scopes
            });

            var userName = "hoa";
            var credential = new UserCredential(flow, userName, new TokenResponse { AccessToken = accessToken, RefreshToken = refreshToken });

            var service = new CalendarService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName
            });
            return service;
        }
    }
}