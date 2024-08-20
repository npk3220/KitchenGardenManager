using Azure.Identity;
using Garden.Create;
using Garden.List;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
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

        services.AddAzureClients(clientBuilder =>
        {
            clientBuilder.AddBlobServiceClient(Environment.GetEnvironmentVariable("BLOB_STORAGE_URL"))
                .WithName("Storage1")
                .WithCredential(new DefaultAzureCredential());

            clientBuilder.AddBlobServiceClient(Environment.GetEnvironmentVariable("BLOB_STORAGE_URL2"))
                .WithName("Storage2")
                .WithCredential(new DefaultAzureCredential());
        });

        // IService‚ÌŽÀ‘•‚ð“o˜^
        // services.AddScoped<IService, CreateGardenService>();
        services.AddScoped<ICreateGardenService, CreateGardenService>();
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
