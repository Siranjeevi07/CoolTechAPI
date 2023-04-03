using BusinessLogicLayer.Sales;

namespace CoolTechAPI.Installer
{
    public class BLInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ISalesBL, SalesBL>();
        }
    }
}
