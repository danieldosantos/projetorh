using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RhSensoERP.Web.Services;
using RhSensoERP.Web.Services.Contracts;

namespace RhSensoERP.Web.Areas.RHU.Controllers;

[Area("RHU")]
[Authorize]
public class FuncionariosController : Controller
{
    private readonly FuncionarioApiService _funcionarioApi;

    public FuncionariosController(FuncionarioApiService funcionarioApi)
    {
        _funcionarioApi = funcionarioApi;
    }

    public async Task<IActionResult> Index()
    {
        var funcionarios = await _funcionarioApi.ListarAsync() ?? Enumerable.Empty<FuncionarioDto>();
        return View(funcionarios);
    }
}
