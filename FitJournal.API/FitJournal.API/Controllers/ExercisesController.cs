using FitJournal.API.DTOs.Exercises;
using FitJournal.API.Handlers.Exercises.Commands;
using FitJournal.API.Handlers.Exercises.Queries;
using FitJournal.Domain.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FitJournal.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExercisesController : Controller
{
    private readonly IMediator _mediator;
    public ExercisesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery]PaginationParameters parameters)
    {
        return await _mediator.Send(new GetExercisesListQuery() { Parameters = parameters});
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] ExerciseDto exerciseDto)
    {
        return await _mediator.Send(new AddExerciseCommand() {ExerciseDto = exerciseDto});
    }
}