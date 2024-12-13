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
        _logger.LogWarning($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} => Deleted idea - ID: {id}");
        return Ok();
    }

}
