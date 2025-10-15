using RhSensoERP.Api.Models;

namespace RhSensoERP.Api.Services;

public class UsuarioService
{
    private readonly InMemoryDatabase _db;

    public UsuarioService(InMemoryDatabase db)
    {
        _db = db;
    }

    public IEnumerable<UsuarioDto> Listar() => _db.Usuarios;

    public UsuarioDto Criar(UsuarioCreateRequest request)
    {
        var usuario = new UsuarioDto(Guid.NewGuid(), request.Nome, request.Email, request.Ativo, request.Permissoes);
        _db.Usuarios.Add(usuario);
        return usuario;
    }

    public UsuarioDto? Atualizar(Guid id, UsuarioCreateRequest request)
    {
        var usuario = _db.Usuarios.FirstOrDefault(u => u.Id == id);
        if (usuario is null)
        {
            return null;
        }

        var atualizado = usuario with
        {
            Nome = request.Nome,
            Email = request.Email,
            Ativo = request.Ativo,
            Permissoes = request.Permissoes.ToArray()
        };

        _db.Usuarios.Remove(usuario);
        _db.Usuarios.Add(atualizado);
        return atualizado;
    }

    public bool Remover(Guid id)
    {
        var usuario = _db.Usuarios.FirstOrDefault(u => u.Id == id);
        if (usuario is null)
        {
            return false;
        }

        _db.Usuarios.Remove(usuario);
        return true;
    }
}
