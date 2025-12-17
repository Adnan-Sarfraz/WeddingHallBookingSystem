using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeddingHall.Application.Interfaces;

namespace WeddingHall.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet("{hallId}")]
        public async Task<IActionResult> GetDashboard(Guid hallId)
        {
            var dashboardData = await _dashboardService.GetDashboardAsync();
            return Ok(new
            {
                success = true,
                data = dashboardData
            });

        }
    }
}
