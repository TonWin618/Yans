using Serilog;
using Serilog.Events;
using Yans.BuildingBlocks.EventBus.InMemory;
using Yans.Modules.Demo.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var initializer = new ModuleInitializer();
initializer.AddModuleServices(builder.Services);

//builder.Services.AddAuthorization();
builder.Services.AddControllers();

//Logging
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSerilogRequestLogging();

app.MapEventHandlers();

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
