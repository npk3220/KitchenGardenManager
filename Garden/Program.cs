using Garden.Create;
using Garden.List;
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
        // services.AddScoped<IService, CreateGardenService>();
        // services.AddScoped<ICreateGardenService, CreateGardenService>();
        services.AddScoped<IGetGardensService, GetGardensService>();
        //services.AddScoped<IService, ShowGardenService>();

        services.AddScoped<CreateGarden>(provider =>
            new CreateGarden(
                provider.GetRequiredService<ILogger<CreateGarden>>(),
                provider.GetRequiredService<CreateGardenService>()));

        services.AddScoped<GetGardens>(provider =>
            new GetGardens(
                provider.GetRequiredService<ILogger<GetGardens>>(),
                provider.GetRequiredService<GetGardensService>()));
    })
.Build();

host.Run();
