using Microsoft.AspNetCore.Mvc;
using RhSensoERP.Api.Models;
using RhSensoERP.Api.Services;

namespace RhSensoERP.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FuncionariosController : ControllerBase
{
    private readonly FuncionarioService _funcionarioService;

    public FuncionariosController(FuncionarioService funcionarioService)
    {
        _funcionarioService = funcionarioService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<FuncionarioDto>> Get() => Ok(_funcionarioService.Listar());

    [HttpPost]
    public ActionResult<FuncionarioDto> Post(FuncionarioCreateRequest request)
    {
        var funcionario = _funcionarioService.Criar(request);
        return CreatedAtAction(nameof(Get), new { id = funcionario.Id }, funcionario);
    }
}
