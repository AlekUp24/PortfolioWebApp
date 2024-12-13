namespace PortfolioWebApp.Api.Controllers;

[ApiController]
[Route("api/[controller]/{id:int}")]
public class IdeasGetIdeaByIDController : Controller
{
    private readonly ILogger _logger;
    private readonly IInnovationIdeasRepository _repository;
    private readonly IMapper _mapper;

    public IdeasGetIdeaByIDController(ILogger<IdeasGetIdeaByIDController> logger, IInnovationIdeasRepository repository, IMapper mapper)
    {
        _logger = logger;
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet(Name = "GetIdeaByID")]
    public async Task<IActionResult> GetIdeaByID(int id)
    {
        try
        {
            InnovationIdeasModel result = new InnovationIdeasModel();
            var response = await _repository.GetIdeaById(id);

            result = _mapper.Map<InnovationIdeasEntity, InnovationIdeasModel>(response);
            _logger.LogInformation($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} => Idea ID = {id} fetched from DB.");
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError($"{ DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} => {ex.Message}");
            return NotFound(null);
        }
    }
}
