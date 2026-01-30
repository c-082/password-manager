namespace PasswordManager.Services;

internal static class ValidationService
{
    public static bool IsValidUsername(string? username)
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
    public static bool IsValidSite(string? site) => !(string.IsNullOrWhiteSpace(site) || site.Length > 255);
    public static bool IsValidPassword(string? password) => !(string.IsNullOrEmpty(password) || password.Length > 128);

}