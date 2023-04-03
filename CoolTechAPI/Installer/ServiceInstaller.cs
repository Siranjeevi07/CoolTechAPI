using CoolTechAPI.Services;
using System;

namespace CoolTechAPI.Installer
{
    public class ServiceInstaller : IInstaller
    {

        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ISalesService, SalesService>();
            
        }
    }
}
