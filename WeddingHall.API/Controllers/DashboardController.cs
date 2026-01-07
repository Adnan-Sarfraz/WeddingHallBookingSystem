using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeddingHall.Application.Common;
using WeddingHall.Application.Interfaces;

namespace WeddingHall.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDashboard()
        {
            var dashboardData = await _dashboardService.GetDashboardAsync();

            return Ok(ApiResponse<object>.SuccessResponse(dashboardData, "Dashboard data fetched successfully"));

        }
    }
}
