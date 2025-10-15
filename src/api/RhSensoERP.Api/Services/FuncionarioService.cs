using RhSensoERP.Api.Models;

namespace RhSensoERP.Api.Services;

public class FuncionarioService
{
    private readonly InMemoryDatabase _db;

    public FuncionarioService(InMemoryDatabase db)
    {
        _db = db;
    }

    public IEnumerable<FuncionarioDto> Listar() => _db.Funcionarios;

    public FuncionarioDto Criar(FuncionarioCreateRequest request)
    {
        var funcionario = new FuncionarioDto(Guid.NewGuid(), request.NomeCompleto, request.Cpf, request.Cargo, request.Admissao, request.Ativo);
        _db.Funcionarios.Add(funcionario);
        return funcionario;
    }
}
