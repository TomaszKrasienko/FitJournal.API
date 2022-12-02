using FitJournal.Infrastructure.Data.Repositories.Exercises;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FitJournal.API.Handlers.Exercises.Commands;

public class GetExercisesListQuery : IRequest<IActionResult> { }

public class GetExercisesListHandler : IRequestHandler<GetExercisesListQuery, IActionResult>
{
    private readonly IExercisesRepository _exercisesRepository;
    public GetExercisesListHandler(IExercisesRepository exercisesRepository)
    {
        _exercisesRepository = exercisesRepository;
    }
    public async Task<IActionResult> Handle(GetExercisesListQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var list = await _exercisesRepository.GetAllAsync();
            if (list.IsNullOrEmpty())
                return new NotFoundResult();
            else
                return new OkObjectResult(list);
        }
        catch (Exception ex)
        {
            return new BadRequestResult();
        }
    }
}