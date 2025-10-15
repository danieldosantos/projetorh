namespace RhSensoERP.Api.Models;

public record LoginRequest(string Username, string Password);
public record LoginResponse(string Token, DateTime ExpiresAt, string NomeUsuario, string Empresa);

public record UsuarioDto(Guid Id, string Nome, string Email, bool Ativo, IEnumerable<string> Permissoes);
public record UsuarioCreateRequest(string Nome, string Email, bool Ativo, IEnumerable<string> Permissoes);

public record GrupoDto(Guid Id, string Nome, string Descricao, IEnumerable<string> Permissoes);
public record GrupoCreateRequest(string Nome, string Descricao, IEnumerable<string> Permissoes);

public record FuncionarioDto(Guid Id, string NomeCompleto, string Cpf, string Cargo, DateOnly Admissao, bool Ativo);
public record FuncionarioCreateRequest(string NomeCompleto, string Cpf, string Cargo, DateOnly Admissao, bool Ativo);

public record DashboardKpi(string Titulo, string Valor, string Variacao, bool VariacaoPositiva);
public record DashboardChart(string Titulo, IEnumerable<string> Labels, IEnumerable<int> Valores);
public record DashboardResponse(IEnumerable<DashboardKpi> Kpis, IEnumerable<DashboardChart> Charts);
