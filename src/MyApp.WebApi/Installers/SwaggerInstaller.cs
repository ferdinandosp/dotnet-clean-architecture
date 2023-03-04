using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MyApp.WebApi.Installers;

public class SwaggerInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        var apiKeySecurityScheme = new OpenApiSecurityScheme()
        {
            Type = SecuritySchemeType.ApiKey,
            Name = "X-API-Key",
            In = ParameterLocation.Header,
            Description = "API Key"
        };

        var apiSecretSecurityScheme = new OpenApiSecurityScheme()
        {
            Type = SecuritySchemeType.ApiKey,
            Name = "X-API-Secret",
            In = ParameterLocation.Header,
            Description = "API Secret"
        };

        var loginTokenSecurityScheme = new OpenApiSecurityScheme()
        {
            Type = SecuritySchemeType.ApiKey,
            Name = "Authorization",
            In = ParameterLocation.Header,
            Description = "Login token",
            Scheme = "Bearer"
        };

        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddSwaggerGen(options =>
        {
            //options.AddSecurityDefinition("X-API-Key", apiKeySecurityScheme);
            //options.AddSecurityDefinition("X-API-Secret", apiSecretSecurityScheme);
            options.AddSecurityDefinition("Bearer", loginTokenSecurityScheme);

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                { new OpenApiSecurityScheme
                {
                    Name = "Bearer",
                    In = ParameterLocation.Header,
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    }
                }, new List<string>() }
            });

            options.OperationFilter<SwaggerDefaultValues>();
        });
    }
}