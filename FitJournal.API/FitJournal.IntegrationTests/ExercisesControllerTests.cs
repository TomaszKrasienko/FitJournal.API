using FitJournal.Domain.Models;
using FitJournal.Infrastructure.Data;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FitJournal.IntegrationTests;

public class ExercisesControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private WebApplicationFactory<Program> _factory;
    private HttpClient _client;
    public ExercisesControllerTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    var dbConnection = services.SingleOrDefault(x =>
                        x.ServiceType == typeof(DbContextOptions<FitJournalDbContext>));
                    services.Remove(dbConnection);
                    services.AddDbContext<FitJournalDbContext>(x => x.UseInMemoryDatabase("TestFitJourna"));
                });
            });
        _client = _factory.CreateClient();
    }
    [Fact]
    public async Task GetAll_ForExercises_ShouldReturnOkResult()
    {
        //Arrange
        Exercise exercise = new Exercise()
        {
            Name = Guid.NewGuid().ToString(),
            Description = Guid.NewGuid().ToString(),
            WithWeight = true
        };
        SeedExercise(exercise);
        //Act
        var response = await _client.GetAsync("api/Exercises?PageNumber=1&PageSize=1");
        //Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    }

    private void SeedExercise(Exercise exercise)
    {
        var scopeFactory = _factory.Services.GetService<IServiceScopeFactory>();
        using var scope = scopeFactory.CreateScope();
        var _dbContext = scope.ServiceProvider.GetService<FitJournalDbContext>();
        _dbContext.Exercises.Add(exercise);
        _dbContext.SaveChanges();
    }
}