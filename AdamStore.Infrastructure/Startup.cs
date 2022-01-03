using AdamStore.Infrastructure.EF;
using Microsoft.Extensions.DependencyInjection;

namespace AdamStore.Infrastructure
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services) => services.AddDbContext<AdamStoreDbContext>();
    }
}