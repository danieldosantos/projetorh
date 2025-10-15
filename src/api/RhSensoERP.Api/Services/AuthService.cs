using RhSensoERP.Api.Models;

namespace RhSensoERP.Api.Services;

public class AuthService
{
    private readonly InMemoryDatabase _db;

    public AuthService(InMemoryDatabase db)
    {
        _db = db;
    }

    public LoginResponse? Login(LoginRequest request)
    {
        var usuario = _db.Usuarios.FirstOrDefault(u =>
            string.Equals(u.Email, request.Username, StringComparison.OrdinalIgnoreCase));

        if (usuario is null)
        {
            return null;
        }

        var token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        return new LoginResponse(token, DateTime.UtcNow.AddHours(8), usuario.Nome, "Empresa Demo");
    }
}
