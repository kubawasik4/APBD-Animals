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
}