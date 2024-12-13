namespace PortfolioWebApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IdeasRefreshLastUpdatedController : Controller
{
    private readonly ILogger _logger;
    private readonly IInnovationIdeasRepository _repository;
    private readonly IMapper _mapper;

    public IdeasRefreshLastUpdatedController(ILogger<IdeasRefreshLastUpdatedController> logger, IInnovationIdeasRepository repository, IMapper mapper)
    {
        _logger = logger;
        _repository = repository;
        _mapper = mapper;
    }

    [HttpPatch("RefreshLastUpdated")]
    public async Task<IActionResult> RefreshLastUpdated([FromBody] InnovationIdeasModel idea)
    {
        var toRefresh = _mapper.Map<InnovationIdeasModel, InnovationIdeasEntity>(idea);
        await _repository.RefreshLastUpdated(toRefresh);
        _logger.LogInformation($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} => Last Updated Refreshed.");
        return Ok();
    }
}
