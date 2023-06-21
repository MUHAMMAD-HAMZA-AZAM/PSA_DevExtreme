using API.App_Exceptions;
using API.Logging;
using API.Middlewares;
using Application.DI;
using MathNet.Numerics;
using MediatR;
using Microsoft.Extensions.Configuration;
using Persistence.DI;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Logging.AddLog4Net();
builder.Services.AddSingleton<ILoggerManager,LoggerManager>();
builder.Services.AddScoped<IExceptionService, ExceptionService>();
//builder.Host.ConfigureLogging(logging =>
//{
//    logging.AddLog4Net(log4NetConfigFile: "log4net.config");
//    logging.ClearProviders();
//    //logging.AddConsole();//for Logging on Console 
//    //logging.AddLog4Net();//for DB Query Logging
//});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Architecture.API");
    });
}

// Global Exception Handling Middleware
app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

