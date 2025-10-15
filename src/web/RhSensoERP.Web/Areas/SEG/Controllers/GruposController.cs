using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RhSensoERP.Web.Services;
using RhSensoERP.Web.Services.Contracts;

namespace RhSensoERP.Web.Areas.SEG.Controllers;

[Area("SEG")]
[Authorize]
public class GruposController : Controller
{
    private readonly GrupoApiService _grupoApi;

    public GruposController(GrupoApiService grupoApi)
    {
        _grupoApi = grupoApi;
    }

    public async Task<IActionResult> Index()
    {
        var grupos = await _grupoApi.ListarAsync() ?? Enumerable.Empty<GrupoDto>();
        return View(grupos);
    }
}
