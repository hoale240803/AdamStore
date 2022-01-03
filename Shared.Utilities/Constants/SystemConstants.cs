using Shared.Entities;
using System.Collections.Generic;

namespace Shared.Utilities.Constants
{
    public class SystemConstants
    {
        public const string MainConnectionString = "apricotDb";
        public const string CartSession = "CartSession";

        public class AppSettings
        {
            public const string DefaultLanguageId = "DefaultLanguageId";
            public const string Token = "Token";
            public const string BaseAddress = "BaseAddress";
        }

        public class ProductSettings
        {
            public const int NumberOfFeaturedProducts = 4;
            public const int NumberOfLatestProducts = 6;
        }

        public class ProductConstants
        {
            public const string NA = "N/A";
        }

        public static List<Language> GetSystemLanguages()
        {

            var result = new List<Language>();
            Language language = new Language
            {
                Id = "vi",
                Name = "vietnam",
                IsDefault = true,
                CategoryTranslations = new List<CategoryTranslation>(),
                ProductTranslations = new List<ProductTranslation>()

            };
            result.Add(language);
            return result;
        }
    }
}