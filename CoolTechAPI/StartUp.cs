using CoolTech.Utilities;
using CoolTechAPI.Hub;
using CoolTechAPI.Installer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Serilog.Events;
using Serilog;
using System.Configuration;
using Microsoft.AspNetCore.Builder;

namespace CoolTechAPI
{
    public class StartUp
    {
        private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }
        public StartUp(IConfiguration configuration)
        {

            Configuration = configuration;
            CommonConfig.connString = configuration.GetSection("ConnectionStrings:connstring").Value;
        }


        public void ConfigureServices(IServiceCollection services)
        {

            // Add services to the container.
            services.AddSignalR();
            //services.AddCors(options => {
            //    options.AddPolicy("CORSPolicy", builder => 
            //    builder.AllowAnyMethod().AllowAnyHeader().AllowCredentials().SetIsOriginAllowed((hosts) => true));
            //});

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("*")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod();
                                  });
            });

            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            //services.AddEndpointsApiExplorer();
            //services.AddSwaggerGen();
            //services.AddMvc();

            services.AddHttpContextAccessor();

            services.InstallServicesInAssembly(Configuration);
            services.AddAuthorization();

            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            services.Configure<SecurityStampValidatorOptions>(options =>
            options.ValidationInterval = TimeSpan.FromSeconds(10));

            Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Verbose)
                    .Enrich.FromLogContext()
                    .WriteTo.File(Configuration.GetSection("LogFile:FilePath").Value,
                        fileSizeLimitBytes: 1_000_000, rollOnFileSizeLimit: true,
                        rollingInterval: RollingInterval.Day, shared: true,
                        flushToDiskInterval: TimeSpan.FromSeconds(1))
                    .CreateLogger();


        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            //if (env.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseExceptionHandler("/error-local-development");

                // Enable middleware to serve generated Swagger as a JSON endpoint.
                app.UseSwagger(); app.UseSwaggerUI();
                // specifying the Swagger JSON endpoint.
                //app.UseSwaggerUI(c =>
                //{
                //    c.SwaggerEndpoint(Configuration.GetSection("Swagger:SwaggerEndPoint").Value, "My API V1");
                //    c.RoutePrefix = string.Empty;
                //});
            }
            else
            {
                app.UseExceptionHandler("/error");
                app.UseSwagger();

                // specifying the Swagger JSON endpoint.
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint(Configuration.GetSection("Swagger:SwaggerEndPoint").Value, "My API V1");
                    c.RoutePrefix = string.Empty;
                });
            }
            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<MessageHub>("/productsList");
            });

            app.UseHttpsRedirection();

            // app.MapControllers();

            //app.Run();
        }
    }
}
