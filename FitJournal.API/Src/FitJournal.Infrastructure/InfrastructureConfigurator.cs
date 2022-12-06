using FitJournal.Infrastructure.Data;
using FitJournal.Infrastructure.Data.Repositories.Exercises;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FitJournal.Infrastructure;

public static class InfrastructureConfigurator
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        ConfigureDbContext(services, configuration);
        ConfigureRepositories(services);
        return services;
    }
    private static void ConfigureRepositories(IServiceCollection service)
    {
        service.AddScoped<IExercisesRepository, ExercisesRepository>();
    }
    private static void ConfigureDbContext(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<FitJournalDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"));
        });
    }

}