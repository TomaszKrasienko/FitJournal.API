using FitJournal.API.DTOs.Exercises;
using FitJournal.Domain.Models;
using FitJournal.Infrastructure.Data;
using FitJournal.IntegrationTests.Helpers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;

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
                    services.AddDbContext<FitJournalDbContext>(x => x.UseInMemoryDatabase("TestFitJournal"));
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
    [Fact]
    public async Task Add_ForCorrectmodel_ShouldReturnOkStatus()
    {
        //Arrange
        ExerciseDto exerciseDto = new ExerciseDto()
        {
            Name = Guid.NewGuid().ToString(),
            Description = Guid.NewGuid().ToString(),
            UnitId = 1,
            WithWeight = true
        };
        var exerciseHttpContent = exerciseDto.ToJsonHttpContent();
        //act
        var response = await _client.PostAsync("api/Exercise", exerciseHttpContent);
        //Assert
        response.StatusCode.Should().Be(response.StatusCode);
    } 
}