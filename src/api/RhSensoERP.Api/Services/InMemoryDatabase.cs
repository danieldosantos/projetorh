using RhSensoERP.Api.Models;

namespace RhSensoERP.Api.Services;

public class InMemoryDatabase
{
    public List<UsuarioDto> Usuarios { get; } = new();
    public List<GrupoDto> Grupos { get; } = new();
    public List<FuncionarioDto> Funcionarios { get; } = new();

    public InMemoryDatabase()
    {
        var permissoesBase = new[] { "SEG.USUARIOS.CONSULTAR", "SEG.USUARIOS.EDITAR" };
        var adminGrupo = new GrupoDto(Guid.NewGuid(), "Administradores", "Acesso completo ao sistema", new[]
        {
            "SEG.USUARIOS.CONSULTAR",
            "SEG.USUARIOS.EDITAR",
            "SEG.GRUPOS.GERENCIAR",
            "RHU.FUNCIONARIOS.GERENCIAR",
            "DASHBOARD.VISUALIZAR"
        });

        Grupos.Add(adminGrupo);

        Usuarios.Add(new UsuarioDto(Guid.NewGuid(), "Administrador", "admin@empresa.com", true, adminGrupo.Permissoes));

        Funcionarios.Add(new FuncionarioDto(Guid.NewGuid(), "Ana Souza", "123.456.789-00", "Analista de RH", new DateOnly(2022, 1, 10), true));
        Funcionarios.Add(new FuncionarioDto(Guid.NewGuid(), "Bruno Lima", "987.654.321-00", "Desenvolvedor", new DateOnly(2023, 3, 15), true));
        Funcionarios.Add(new FuncionarioDto(Guid.NewGuid(), "Carla Mendes", "111.222.333-44", "Coordenadora", new DateOnly(2021, 7, 1), false));
    }
}
