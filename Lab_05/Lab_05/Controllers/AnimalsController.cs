using Lab_05.Database;
using Microsoft.AspNetCore.Mvc;

namespace Lab_05.Controllers;

[ApiController]
[Route("[controller]")]
public class AnimalsController : ControllerBase
{

    [HttpGet]
    public IActionResult GetAnimals()
    {
        // return Ok(StaticData.animals);
        return Ok(new MockDb().Animals);
    }
}