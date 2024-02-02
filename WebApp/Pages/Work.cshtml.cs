using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class WorkModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IWorkService _workService;

        public IList<Work> Works { get; private set; }

        public WorkModel(ILogger<IndexModel> logger, IWorkService workService)
        {
            _logger = logger;
            _workService = workService;
        }

        public async Task OnGetAsync()
        {
            Works = await _workService.GetAll();
        }
    }
}
