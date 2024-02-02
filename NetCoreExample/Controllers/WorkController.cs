using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkController : ControllerBase
    {

        private readonly ILogger<WorkController> _logger;
        private readonly IWorkService _workService;

        public WorkController(ILogger<WorkController> logger, IWorkService workService)
        {
            _logger = logger;
            _workService = workService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<Work>> Get()
        {
            return await _workService.GetAll();
        }
    }
}