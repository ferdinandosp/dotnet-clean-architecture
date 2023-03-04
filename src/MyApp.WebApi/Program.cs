using Asp.Versioning;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using MediatR;
using Microsoft.Extensions.Options;
using MyApp.Application;
using MyApp.Infrastructure;
using MyApp.WebApi;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

var appSettings = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .Build();

MyApp.Application.DependencyResolver.DependencyResolverService.Register(builder.Services);
MyApp.Infrastructure.DependencyResolver.DependencyResolverService.Register(builder.Services, appSettings);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new DefaultInfrastructureModule());
    containerBuilder.RegisterModule(new AutoMapperModule());
});
builder.Host.ConfigureServices(services =>
{
    services.AddMediatR(typeof(DefaultApplicationModule).Assembly);
});
builder.Services.AddControllers();
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1.0);
    options.ApiVersionReader = new MediaTypeApiVersionReader();
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
}).AddApiExplorer();
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen(options =>
{
    options.OperationFilter<SwaggerDefaultValues>();
});

// TODO: Add Installers pattern.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
        options =>
        {
            foreach (var description in app.DescribeApiVersions())
            {
                options.SwaggerEndpoint(
                    $"/swagger/{description.GroupName}/swagger.json",
                    description.GroupName);
            }
        });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    MyApp.Infrastructure.DependencyResolver.DependencyResolverService.MigrateDatabase(scope.ServiceProvider);
}

app.Run();
