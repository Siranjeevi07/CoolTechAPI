using Microsoft.AspNetCore.Hosting;

namespace CoolTechAPI.Installer
{
    public static class InstallerExtensions
    {
        public static void InstallServicesInAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            var installers = typeof(StartUp).Assembly.ExportedTypes.Where(x =>
              typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Select(Activator.CreateInstance).Cast<IInstaller>().ToList();
            installers.ForEach(Installer => Installer.InstallServices(services, configuration));
        }
    }
}
