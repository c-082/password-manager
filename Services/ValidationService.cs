namespace PasswordManager.Services;

internal static class ValidationService
{
    internal static bool IsValidUsername(string? username)
    {
        if (string.IsNullOrWhiteSpace(username))
        {
            return false;
        }
        if (username.Length > 254)
        {
            return false;
        }
        return true;
    }
    internal static bool IsValidSite(string? site) => !(string.IsNullOrWhiteSpace(site) || site.Length > 255);
    internal static bool IsValidPassword(string? password) => !(string.IsNullOrEmpty(password) || password.Length > 128);

}