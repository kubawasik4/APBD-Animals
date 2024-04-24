using Microsoft.AspNetCore.Mvc;

namespace AnimalsDbConnection.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AnimalsController : ControllerBase
{
    private IAnimalsService _animalsService;

    public AnimalsController(IAnimalsService animalsService)
    {
        _animalsService = animalsService;
    }

    [HttpGet]
    public IActionResult GetAnimals(string orderBy)
    {
        var animals = _animalsService.GetAnimals(orderBy);
        return Ok(animals);
    }

    [HttpPost]
    public IActionResult AddAnimal(Animal animal)
    {
        var counter = _animalsService.AddAnimal(animal);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, Animal animal)
    {
        var counter = _animalsService.UpdateAnimal(id, animal);
        if (counter == 1)
        {
            return Ok();
        }
        return StatusCode(500, "Błąd podczas aktualizacji danych");
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        var counter = _animalsService.DeleteAnimal(id);
        if (counter == 1)
        {
            return Ok();
        }

        return NotFound();

    }
}