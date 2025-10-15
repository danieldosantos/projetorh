using Microsoft.AspNetCore.Mvc;
using RhSensoERP.Api.Models;
using RhSensoERP.Api.Services;

namespace RhSensoERP.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly UsuarioService _usuarioService;

    public UsuariosController(UsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<UsuarioDto>> Get() => Ok(_usuarioService.Listar());

    [HttpPost]
    public ActionResult<UsuarioDto> Post(UsuarioCreateRequest request)
    {
        var usuario = _usuarioService.Criar(request);
        return CreatedAtAction(nameof(Get), new { id = usuario.Id }, usuario);
    }

    [HttpPut("{id:guid}")]
    public ActionResult<UsuarioDto> Put(Guid id, UsuarioCreateRequest request)
    {
        var usuario = _usuarioService.Atualizar(id, request);
        return usuario is null ? NotFound() : Ok(usuario);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id) => _usuarioService.Remover(id) ? NoContent() : NotFound();
}
