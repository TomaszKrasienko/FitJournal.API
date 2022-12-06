using AutoMapper;
using FitJournal.API.DTOs.Exercises;
using FitJournal.Domain.Models;
using FitJournal.Infrastructure.Data;
using FitJournal.Infrastructure.Data.Repositories.Exercises;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FitJournal.API.Handlers.Exercises.Commands;

public record EditExerciseCommand : IRequest<IActionResult>
{
    public int ExerciseId { get; init; }
    public ExerciseDto? ExerciseDto { get; init; }
}

public class EditExerciseCommandHandler : IRequestHandler<EditExerciseCommand, IActionResult>
{
    private readonly IMapper _mapper;
    private readonly IExercisesRepository _exercisesRepository;
    public EditExerciseCommandHandler(IMapper mapper, IExercisesRepository exercisesRepository)
    {
        _mapper = mapper;
        _exercisesRepository = exercisesRepository;
    }
    public async Task<IActionResult> Handle(EditExerciseCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Exercise>(request.ExerciseDto);
        var result = await _exercisesRepository.EditAsync(request.ExerciseId, entity);
        return new OkObjectResult(result);
    }
}