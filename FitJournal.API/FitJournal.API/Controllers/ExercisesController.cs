using FitJournal.API.Handlers.Exercises.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FitJournal.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ExercisesController : Controller
{
    private readonly IMediator _mediator;
    public ExercisesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return await _mediator.Send(new GetExercisesListQuery());
    }
}