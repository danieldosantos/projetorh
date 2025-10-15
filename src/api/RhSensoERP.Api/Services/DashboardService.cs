using RhSensoERP.Api.Models;

namespace RhSensoERP.Api.Services;

public class DashboardService
{
    private readonly InMemoryDatabase _db;

    public DashboardService(InMemoryDatabase db)
    {
        _db = db;
    }

    public DashboardResponse ObterResumo()
    {
        var ativos = _db.Funcionarios.Count(f => f.Ativo);
        var inativos = _db.Funcionarios.Count(f => !f.Ativo);

        var kpis = new[]
        {
            new DashboardKpi("Funcionários Ativos", ativos.ToString(), "+5%", true),
            new DashboardKpi("Funcionários Inativos", inativos.ToString(), "-2%", false),
            new DashboardKpi("Usuários do Sistema", _db.Usuarios.Count.ToString(), "+1%", true)
        };

        var charts = new[]
        {
            new DashboardChart(
                "Admissões por Mês",
                new[] { "Jan", "Fev", "Mar", "Abr", "Mai", "Jun" },
                new[] { 3, 5, 2, 4, 6, 3 }
            )
        };

        return new DashboardResponse(kpis, charts);
    }
}
