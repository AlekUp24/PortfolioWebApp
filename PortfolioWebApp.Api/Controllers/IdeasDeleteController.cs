namespace PortfolioWebApp.Api.Controllers;

[ApiController]
[Route("api/[controller]/{id:int}")]
public class IdeasDeleteController : Controller
{
    private readonly ILogger _logger;
    private readonly IInnovationIdeasRepository _repository;
    private readonly IMapper _mapper;

    public IdeasDeleteController(ILogger<IdeasDeleteController> logger, IInnovationIdeasRepository repository, IMapper mapper) 
    {
        _logger = logger;
        _repository = repository;
        _mapper = mapper;
    }

    [HttpDelete(Name = "DeleteIdea")]
    public async Task<IActionResult> DeleteIdea(int id)
    {
        await _repository.DeleteIdea(id);
        return Ok();
    }

}
