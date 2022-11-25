using Microsoft.AspNetCore.Mvc;

namespace FitJournal.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ExercisesController : Controller
{
    public ExercisesController()
    {
        
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok();
    }
}