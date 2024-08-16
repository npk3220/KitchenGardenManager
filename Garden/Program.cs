using Garden;
using Garden.Create;
using Garden.Update;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Models;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();

        services.AddDbContext<HomeGardenContext>(options =>
        options.UseSqlServer(Environment.GetEnvironmentVariable("SQL_CONNECTIONSTRING")));

        // IService‚ÌŽÀ‘•‚ð“o˜^
        services.AddScoped<IService, CreateGardenService>();
        services.AddScoped<IService, ShowGardenService>();

        services.AddScoped<CreateGarden>(provider =>
            new CreateGarden(provider.GetRequiredService<ILogger<CreateGarden>>(), provider.GetRequiredService<CreateGardenService>()));
    })
.Build();

host.Run();
