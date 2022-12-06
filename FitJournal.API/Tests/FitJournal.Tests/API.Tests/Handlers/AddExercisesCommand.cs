using AutoMapper;
using FitJournal.API.DTOs.Exercises;
using FitJournal.API.Handlers.Exercises.Commands;
using FitJournal.Domain.Models;
using FitJournal.Infrastructure.Data.Repositories.Exercises;
using FitJournal.Tests.Helpers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FitJournal.Tests.API.Tests.Handlers;

public class AddExercisesCommandTests
{
    private Mock<IExercisesRepository>? _exercisesRepositoryMock;
    private Mapper _mapper;
    public AddExercisesCommandTests()
    {
        _exercisesRepositoryMock = new Mock<IExercisesRepository>();
        _mapper = AutoMapperProvider.GetAutoMapper();
    }

    [Fact]
    public async Task Handle_ForExerciseDto_ShouldReturnOkObjectResult()
    {
        //Arrange
        ExerciseDto exerciseDto = new ExerciseDto()
        {
            Name = Guid.NewGuid().ToString(),
            Description = Guid.NewGuid().ToString(),
            UnitId = 1,
            WithWeight = true
        };
        _exercisesRepositoryMock.Setup(x => x.AddAsync(It.IsAny<Exercise>())).ReturnsAsync(It.IsAny<Exercise>());
        var addExercisesCommand = new AddExerciseCommandHandler(_mapper, _exercisesRepositoryMock.Object);
        //Act
        var result = await addExercisesCommand.Handle(new AddExerciseCommand() {ExerciseDto = exerciseDto}, new CancellationToken());
        //Assert
        result.Should().BeOfType(typeof(OkObjectResult));
    }
}