using HomeAssignment.Database;
using Microsoft.AspNetCore.Mvc;

namespace HomeAssignment.Controllers;

[ApiController]
[Route("[controller]")]
public class AnimalsController : ControllerBase
{

    [HttpGet]
    public IActionResult GetAnimals()
    {
        // return Ok(StaticData.animals);
        return Ok(new AnimalDatabase().Animals);
    }
}