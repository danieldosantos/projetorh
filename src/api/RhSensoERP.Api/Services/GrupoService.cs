using RhSensoERP.Api.Models;

namespace RhSensoERP.Api.Services;

public class GrupoService
{
    private readonly InMemoryDatabase _db;

    public GrupoService(InMemoryDatabase db)
    {
        _db = db;
    }

    public IEnumerable<GrupoDto> Listar() => _db.Grupos;

    public GrupoDto Criar(GrupoCreateRequest request)
    {
        var grupo = new GrupoDto(Guid.NewGuid(), request.Nome, request.Descricao, request.Permissoes);
        _db.Grupos.Add(grupo);
        return grupo;
    }

    public GrupoDto? Atualizar(Guid id, GrupoCreateRequest request)
    {
        var grupo = _db.Grupos.FirstOrDefault(g => g.Id == id);
        if (grupo is null)
        {
            return null;
        }

        var atualizado = grupo with
        {
            Nome = request.Nome,
            Descricao = request.Descricao,
            Permissoes = request.Permissoes.ToArray()
        };

        _db.Grupos.Remove(grupo);
        _db.Grupos.Add(atualizado);
        return atualizado;
    }
}
