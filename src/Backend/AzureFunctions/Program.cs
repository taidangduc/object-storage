using Application;
using Infrastructure.Imaging;
using Infrastructure.Storage;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence;

var builder = FunctionsApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.ConfigureFunctionsWebApplication();

builder.Services
    .AddApplicationInsightsTelemetryWorkerService()
    .ConfigureFunctionsApplicationInsights();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

var storageOptions = new StorageOptions();
builder.Configuration.GetSection("Storage").Bind(storageOptions);;

builder.Services
    .AddPersistence(connectionString)
    .AddApplicationServices()
    .AddStorage(storageOptions)
    .AddSingleton<ImageProcessingService>();

builder.Build().Run();
