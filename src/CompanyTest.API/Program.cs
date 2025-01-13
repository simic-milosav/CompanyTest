using CompanyTest.API.Extensions;
using CompanyTest.Application;
using CompanyTest.Infrastructure;
using FastEndpoints;
using FastEndpoints.Swagger;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ILoggerFactory, LoggerFactory>();
builder.Services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));

builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services
    .AddFastEndpoints()
    .SwaggerDocument(o =>
    {
        o.DocumentSettings = s =>
        {
            s.Title = "My API";
            s.Version = "v1";            
        };
    });

List<Assembly> mediatRAssemblies = [typeof(Program).Assembly];
builder.Services.AddApplicationServices(mediatRAssemblies);

builder.Services.AddMediatR(
            c => c.RegisterServicesFromAssemblies([.. mediatRAssemblies]));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.ApplyMigrations();
}

app
    .UseDefaultExceptionHandler()
    .UseFastEndpoints()
    .UseSwaggerGen();

app.Run();
