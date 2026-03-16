namespace PasswordManager.Services;

static class ValidationService
{
    public static bool IsValidUsername(string? username) => !string.IsNullOrWhiteSpace(username) && username.Length <= 254;
    public static bool IsValidSite(string? site) => !string.IsNullOrWhiteSpace(site) && site.Length <= 255;
    public static bool IsValidPassword(string? password) => !string.IsNullOrEmpty(password) && password.Length <= 128;

}