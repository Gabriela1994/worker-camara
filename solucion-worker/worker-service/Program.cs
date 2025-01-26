using DataAccess.Models;
using DataAccess.Servicios;
using Microsoft.EntityFrameworkCore;
using worker_service;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        var connectionString = hostContext.Configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<BdInfraccionesContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddHostedService<Worker>();
        services.AddScoped<DataService>();

        
    })
    .Build();

await host.RunAsync();