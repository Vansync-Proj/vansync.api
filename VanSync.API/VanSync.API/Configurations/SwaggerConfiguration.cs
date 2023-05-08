using Microsoft.OpenApi.Models;

namespace VanSync.API.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void AddSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new()
                {
                    Title = "VanSync",
                    Description = "novo uber de van",
                    Contact = new OpenApiContact { Name = "Equipe Sync", Email = "vansync@outlook.com" },
                    Version = "v1"
                });

                //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                //{
                //    Type = SecuritySchemeType.Http,
                //    BearerFormat = "JWT",
                //    In = ParameterLocation.Header,
                //    Scheme = "bearer",
                //    Description = "Please insert JWT token"
                //});

                //c.AddSecurityRequirement(new OpenApiSecurityRequirement
                //{
                //    {
                //        new OpenApiSecurityScheme
                //        {
                //            Reference = new OpenApiReference
                //            {
                //                Type = ReferenceType.SecurityScheme,
                //                Id = "Bearer"
                //            }
                //        },
                //        new string[] { }
                //    }
                //});
            });
        }
    }
}
