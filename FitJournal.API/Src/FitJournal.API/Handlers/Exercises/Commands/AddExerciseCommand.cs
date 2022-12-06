using AutoMapper;
using FitJournal.API.DTOs.Exercises;
using FitJournal.Domain.Models;
using FitJournal.Infrastructure.Data.Repositories.Exercises;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FitJournal.API.Handlers.Exercises.Commands;

public class AddExerciseCommand : IRequest<IActionResult>
{
    public ExerciseDto? ExerciseDto { get; init; }
}

public class AddExerciseCommandHandler : IRequestHandler<AddExerciseCommand, IActionResult>
{
    private readonly IMapper _mapper;
    private readonly IExercisesRepository _exercisesRepository;
    public AddExerciseCommandHandler(IMapper mapper, IExercisesRepository exercisesRepository)
    {
        _mapper = mapper;
        _exercisesRepository = exercisesRepository;
    }
    public async Task<IActionResult> Handle(AddExerciseCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Exercise>(request.ExerciseDto);
        var result = await _exercisesRepository.AddAsync(entity);
        return new OkObjectResult(result);
    }
}