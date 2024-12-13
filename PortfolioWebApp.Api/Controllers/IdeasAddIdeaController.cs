namespace PortfolioWebApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IdeasAddIdeaController : Controller
{
    private readonly ILogger _logger;
    private readonly IInnovationIdeasRepository _repository;
    private readonly IMapper _mapper;

    public IdeasAddIdeaController(ILogger<IdeasAddIdeaController> logger, IInnovationIdeasRepository repository, IMapper mapper)
    {
        _logger = logger;
        _repository = repository;
        _mapper = mapper;
    }

    [HttpPost("AddIdea")]
    public async Task<IActionResult> AddIdea([FromBody] InnovationIdeasModel idea)
    {
        try
        {
            var toAdd = _mapper.Map<InnovationIdeasModel, InnovationIdeasEntity>(idea);
            await _repository.AddToIdeas(toAdd);
            _logger.LogInformation($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} => Idea added succesfully!");
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} => Idea not added! - {ex.Message}");
            return StatusCode(500);
        }
    }
}

