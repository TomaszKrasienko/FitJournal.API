using FitJournal.Domain.Wrappers;
using FitJournal.Infrastructure.Data.Repositories.Exercises;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FitJournal.API.Handlers.Exercises.Queries;

public record GetExercisesListQuery : IRequest<IActionResult>
{
    public PaginationParameters? Parameters { get; init; }    
}

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
            var list = await _exercisesRepository.GetAllAsync(request.Parameters);
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