using Microsoft.AspNetCore.Mvc;
using RhSensoERP.Api.Models;
using RhSensoERP.Api.Services;

namespace RhSensoERP.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DashboardController : ControllerBase
{
    private readonly DashboardService _dashboardService;

    public DashboardController(DashboardService dashboardService)
    {
        _dashboardService = dashboardService;
    }

    [HttpGet]
    public ActionResult<DashboardResponse> Get() => Ok(_dashboardService.ObterResumo());
}
