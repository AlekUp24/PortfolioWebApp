namespace PortfolioWebApp.Api.Controllers;

[ApiController]
[Route("api/[controller]/{id:int}")]
public class IdeasChangeStatusController : Controller
{
    private readonly ILogger _logger;
    private readonly IInnovationIdeasRepository _repository;
    private readonly IMapper _mapper;

    public IdeasChangeStatusController(ILogger<IdeasGetAllController> logger, IInnovationIdeasRepository repository, IMapper mapper)
    {
        _logger = logger;
        _repository = repository;
        _mapper = mapper;
    }

    [HttpPatch(Name = "ChangeStatus")]
    public async Task<IActionResult> ChangeStatus(int id)
    {
        await _repository.ChangeStatus(id);
        _logger.LogInformation($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} => Changed status - ID: {id}");
        return Ok();
    } 
}
