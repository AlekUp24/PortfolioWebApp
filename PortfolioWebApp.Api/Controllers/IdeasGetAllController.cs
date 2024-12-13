namespace PortfolioWebApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IdeasGetAllController : Controller
{
    private readonly ILogger _logger;
    private readonly IInnovationIdeasRepository _repository;
    private readonly IMapper _mapper;

    public IdeasGetAllController(ILogger<IdeasGetAllController> logger, IInnovationIdeasRepository repository, IMapper mapper)
    {
        _logger = logger;
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet(Name = "GetAllIdeas")]
    public async Task<IActionResult> GetAllIdeas()
    {
        try
        {
            List<InnovationIdeasModel> results = new List<InnovationIdeasModel>();
            var list = await _repository.GetAllIdeas();

            if (list != null)
            {
                foreach (InnovationIdeasEntity item in list)
                {
                    results.Add(_mapper.Map<InnovationIdeasEntity, InnovationIdeasModel>(item));
                }
                _logger.LogInformation("Get All ideas worked!");
            }

            return Ok(results);

        }
        catch (Exception ex)
        {
            _logger.LogInformation(ex.Message);
            return NotFound(null);
        }
    }
}
