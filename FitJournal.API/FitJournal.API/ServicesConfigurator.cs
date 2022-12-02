using System.Reflection;
using FitJournal.Infrastructure;
using MediatR;

namespace FitJournal.API;

public class ServicesConfigurator
{
    private readonly IServiceCollection _services;
    private readonly IConfiguration _configuration;
    private static ServicesConfigurator? _instance;
    public static ServicesConfigurator Create(IServiceCollection services, IConfiguration configuration)
    {
        if (_instance is null)
            _instance = new ServicesConfigurator(services, configuration);
        return _instance;
    }
    private ServicesConfigurator(IServiceCollection services, IConfiguration configuration)
    {
        _services = services;
        _configuration = configuration;
    }
    public void ConfigureServices()
    {
        _services.AddInfrastructureServices(_configuration);
        ConfigureMediatr();
    }
    private void ConfigureMediatr()
    {
        _services.AddMediatR(Assembly.GetExecutingAssembly());
    }
}