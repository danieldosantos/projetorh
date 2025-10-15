using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RhSensoERP.Web.Services;
using RhSensoERP.Web.Services.Contracts;

namespace RhSensoERP.Web.Areas.SEG.Controllers;

[Area("SEG")]
[Authorize]
public class UsuariosController : Controller
{
    private readonly UsuarioApiService _usuarioApi;

    public UsuariosController(UsuarioApiService usuarioApi)
    {
        _usuarioApi = usuarioApi;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var usuarios = await _usuarioApi.ListarAsync() ?? Enumerable.Empty<UsuarioDto>();
        return View(usuarios);
    }

    [HttpPost]
    public async Task<IActionResult> Index([FromBody] UsuarioRequest request)
    {
        var usuario = await _usuarioApi.CriarAsync(request);
        return usuario is null ? BadRequest() : Ok(usuario);
    }
}
