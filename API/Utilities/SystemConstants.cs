namespace API.Utilities
{
    public static class SystemConstants
    {
        public const string MainConnectionString = "eShopSolutionDb";
        public const string CartSession = "CartSession";

        public static class AppSettings
        {
            public const string DefaultLanguageId = "DefaultLanguageId";
            public const string Token = "Token";
            public const string BaseAddress = "BaseAddress";
        }

        public static class ProductSettings
        {
            public const int NumberOfFeaturedProducts = 4;
            public const int NumberOfLatestProducts = 6;
        }

        public static class ProductConstants
        {
            public const string NA = "N/A";
            
        }
    }
}