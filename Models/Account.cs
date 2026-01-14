namespace PasswordManager.Models;

class Account
{
    public string Email { get; set; } = string.Empty;
    public string Site { get; set; } = string.Empty;
    public string EncryptedPassword { get; set; } = string.Empty;
}