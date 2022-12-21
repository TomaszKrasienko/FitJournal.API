using FitJournal.Infrastructure.Data.Repositories.Exercises;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FitJournal.API.Handlers.Exercises.Commands;

public record DeleteExerciseCommand : IRequest<IActionResult>
{
    public int Id { get; init; }
}
public class DeleteExerciseCommandHandler : IRequestHandler<DeleteExerciseCommand, IActionResult>
{
    private readonly IExercisesRepository _exercisesRepository;
    public DeleteExerciseCommandHandler(IExercisesRepository exercisesRepository)
    {
        _exercisesRepository = exercisesRepository;
    }
    public async Task<IActionResult> Handle(DeleteExerciseCommand request, CancellationToken cancellationToken)
    {
        int result = await _exercisesRepository.DeleteAsync(request.Id);
        return new OkObjectResult(result);
    }
}