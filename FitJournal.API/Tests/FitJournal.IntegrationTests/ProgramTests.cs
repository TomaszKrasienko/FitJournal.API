using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace FitJournal.IntegrationTests;

public class ProgramTests : IClassFixture<WebApplicationFactory<Program>>
{
    private WebApplicationFactory<Program> _factory;
    private List<Type> _controllerTypes;

    public ProgramTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _controllerTypes = typeof(ControllerBase)
            .Assembly
            .GetTypes()
            .Where(x => x.IsSubclassOf(typeof(ControllerBase)))
            .ToList();
        _factory = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                _controllerTypes.ForEach(x => services.AddScoped(x));
            });
        });
    }

    [Fact]
    public void ConfigureServices_ForController_RegisteredAllDependencies()
    {
        var scopefactory = _factory.Services.GetService<IServiceScopeFactory>();
        using var scope = scopefactory.CreateScope();
        _controllerTypes.ForEach(x =>
        {
            var controller = scope.ServiceProvider.GetService(x);
            controller.Should().BeNull();
        });
    }
    
}