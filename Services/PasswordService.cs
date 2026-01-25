using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;

namespace PasswordManager.Services;

internal static class PasswordService
{
    private static readonly IDataProtector _protector = CreateProtector();
    private static IDataProtector CreateProtector()
    {
        var services = new ServiceCollection();
        services.AddDataProtection()
                .SetApplicationName("PasswordManagerApp");
        var serviceProvider = services.BuildServiceProvider();
        var provider = serviceProvider.GetRequiredService<IDataProtectionProvider>();
        return provider.CreateProtector("Passwords");
    }

    internal static string Encrypt(string plainPassword) => _protector.Protect(plainPassword);
    internal static string Decrypt(string encryptedPassword) => _protector.Unprotect(encryptedPassword);
}