using App.Api.Extensions;
using App.Api.Middleware;
using App.Domain;
using App.Domain.Interfaces;
using App.Domain.Interfaces.Repositories;
using App.Infrastructure.Repositories;
using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using System.Reflection;
using WebApp.Api.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddControllersAsServices();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDependencies();


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    // configure all controllers that inherit from BaseApiController to have properties injected
    containerBuilder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
        .Where(t => t.IsSubclassOf(typeof(BaseApiController)))
        .PropertiesAutowired();
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.UseAuthorization();

app.UseMiddleware<AuthMiddleware>();

app.MapControllers();

app.Run();
