using System.ComponentModel.DataAnnotations;

namespace RhSensoERP.Web.Models;

public class LoginViewModel
{
    [Required]
    [EmailAddress]
    public string Username { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
}

public record LoginResult(string Token, DateTime ExpiresAt, string NomeUsuario, string Empresa);
