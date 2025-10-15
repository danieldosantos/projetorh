using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RhSensoERP.Web.Models;
using RhSensoERP.Web.Services;

namespace RhSensoERP.Web.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly DashboardApiService _dashboardApi;

    public HomeController(DashboardApiService dashboardApi)
    {
        _dashboardApi = dashboardApi;
    }

    public async Task<IActionResult> Index()
    {
        var dashboard = await _dashboardApi.ObterResumoAsync();
        return View(new DashboardViewModel(dashboard));
    }
}
