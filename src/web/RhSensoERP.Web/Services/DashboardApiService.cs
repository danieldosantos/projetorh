using RhSensoERP.Web.Services.Contracts;

namespace RhSensoERP.Web.Services;

public class DashboardApiService
{
    private readonly ApiService _apiService;

    public DashboardApiService(ApiService apiService)
    {
        _apiService = apiService;
    }

    public Task<DashboardResponse?> ObterResumoAsync() => _apiService.GetAsync<DashboardResponse>("api/dashboard");
}
