namespace PasswordManager.Models;

internal class Account
{
    public string Username { get; set; } = string.Empty;
    public string Site { get; set; } = string.Empty;
    public string EncryptedPassword { get; set; } = string.Empty;
}