namespace PasswordManager.Services;

static class ValidationService
{
    public static bool IsValidEmail(string? email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;
        if (email.Length > 254)
            return false;
        var atIndex = email.IndexOf('@');
        if (atIndex == -1 || email.LastIndexOf('@') != atIndex)
            return false;
        if (atIndex == 0 || atIndex == email.Length - 1)
            return false;
        string domainPart = email[(atIndex + 1)..];
        if (!domainPart.Contains('.'))
            return false;
        return true;
    }
    public static bool IsValidSite(string? site) => !(string.IsNullOrWhiteSpace(site) || site.Length > 255);
    public static bool IsValidPassword(string? password) => !(string.IsNullOrEmpty(password) || password.Length > 128);
}