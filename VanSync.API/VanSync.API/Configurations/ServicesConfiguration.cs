using VanSync.Business.Services;
using VanSync.Domain.Interfaces.Repositorys;
using VanSync.Domain.Interfaces.Services;
using VanSync.Infra.Data.Repositorys;

namespace VanSync.API.Configurations
{
    public static class ServicesConfiguration
    {
        public static void AddServiceConfiguration(this WebApplicationBuilder builder)
        {
            //builder.AddAuthentication();
            builder.Services.AddSingleton(typeof(string), "");
            builder.AddSwagger();
            builder.ConnectionStringRepository();

            //builder.Services.AddCors(options =>
            //{
            //    options.AddPolicy(name: "default",
            //                      builder =>
            //                      {
            //                          builder.AllowAnyMethod()
            //                                 .AllowAnyHeader()
            //                                 .SetIsOriginAllowed(origin => true)
            //                                 .AllowCredentials();
            //                      });
            //});

            #region [Services]
            builder.Services.AddScoped<IUserServices, UserServices>();
            builder.Services.AddScoped<IAdminServices, AdminServices>();
            builder.Services.AddScoped<ILoginServices, LoginServices>();
            #endregion [Services]

            #region [Repositorys]
            builder.Services.AddScoped<IUserRepositorys, UserRepositorys>();
            builder.Services.AddScoped<IAdminRepositorys, AdminRepositorys>();
            builder.Services.AddScoped<ILoginRepositorys, LoginRepositorys>();
            #endregion [Repositorys]
        }
    }
}
