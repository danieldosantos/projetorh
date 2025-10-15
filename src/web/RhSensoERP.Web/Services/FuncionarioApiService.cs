using RhSensoERP.Web.Services.Contracts;

namespace RhSensoERP.Web.Services;

public class FuncionarioApiService
{
    private readonly ApiService _apiService;

    public FuncionarioApiService(ApiService apiService)
    {
        _apiService = apiService;
    }

    public Task<IEnumerable<FuncionarioDto>?> ListarAsync() => _apiService.GetAsync<IEnumerable<FuncionarioDto>>("api/funcionarios");
    public Task<FuncionarioDto?> CriarAsync(FuncionarioRequest request) => _apiService.PostAsync<FuncionarioRequest, FuncionarioDto>("api/funcionarios", request);
}
