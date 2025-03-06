using Microsoft.Extensions.DependencyInjection;
using System;

// Create Service Collection
ServiceCollection services = new ServiceCollection();
services.AddSingleton<VehicleService>();
services.AddScoped<App>();
ServiceProvider serviceProvider = services.BuildServiceProvider();

//Converting null literal or possible null value to non-nullable type.
App app = serviceProvider.GetService<App>() ?? throw new InvalidOperationException("App was not provided to the service collection.");

//Dereference of a possibly null reference.
await app.Run();