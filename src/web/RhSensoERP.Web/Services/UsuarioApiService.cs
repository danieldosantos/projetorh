using RhSensoERP.Web.Services.Contracts;

namespace RhSensoERP.Web.Services;

public class UsuarioApiService
{
    private readonly ApiService _apiService;

    public UsuarioApiService(ApiService apiService)
    {
        _apiService = apiService;
    }

    public Task<IEnumerable<UsuarioDto>?> ListarAsync() => _apiService.GetAsync<IEnumerable<UsuarioDto>>("api/usuarios");
    public Task<UsuarioDto?> CriarAsync(UsuarioRequest request) => _apiService.PostAsync<UsuarioRequest, UsuarioDto>("api/usuarios", request);
}
