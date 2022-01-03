using Data.EF;
using Microsoft.Extensions.DependencyInjection;

namespace Data
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services) => services.AddDbContext<AdamStoreDbContext>();
    }
}