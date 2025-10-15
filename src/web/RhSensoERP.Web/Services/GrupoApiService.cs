using RhSensoERP.Web.Services.Contracts;

namespace RhSensoERP.Web.Services;

public class GrupoApiService
{
    private readonly ApiService _apiService;

    public GrupoApiService(ApiService apiService)
    {
        _apiService = apiService;
    }

    public Task<IEnumerable<GrupoDto>?> ListarAsync() => _apiService.GetAsync<IEnumerable<GrupoDto>>("api/grupos");
    public Task<GrupoDto?> CriarAsync(GrupoRequest request) => _apiService.PostAsync<GrupoRequest, GrupoDto>("api/grupos", request);
}
