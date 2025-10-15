using Microsoft.AspNetCore.Mvc;
using RhSensoERP.Api.Models;
using RhSensoERP.Api.Services;

namespace RhSensoERP.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GruposController : ControllerBase
{
    private readonly GrupoService _grupoService;

    public GruposController(GrupoService grupoService)
    {
        _grupoService = grupoService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<GrupoDto>> Get() => Ok(_grupoService.Listar());

    [HttpPost]
    public ActionResult<GrupoDto> Post(GrupoCreateRequest request)
    {
        var grupo = _grupoService.Criar(request);
        return CreatedAtAction(nameof(Get), new { id = grupo.Id }, grupo);
    }

    [HttpPut("{id:guid}")]
    public ActionResult<GrupoDto> Put(Guid id, GrupoCreateRequest request)
    {
        var grupo = _grupoService.Atualizar(id, request);
        return grupo is null ? NotFound() : Ok(grupo);
    }
}
