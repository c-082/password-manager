using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;

namespace PasswordManager.Services;

static class PasswordService
{
    private static readonly IDataProtector Protector = CreateProtector();
    private static IDataProtector CreateProtector()
    {
        var services = new ServiceCollection();
        services.AddDataProtection()
                .SetApplicationName("PasswordManagerApp");
        var serviceProvider = services.BuildServiceProvider();
        var provider = serviceProvider.GetRequiredService<IDataProtectionProvider>();
        return provider.CreateProtector("Passwords");
    }
    public static string Encrypt(string plainPassword) => Protector.Protect(plainPassword);
    public static string Decrypt(string encryptedPassword) => Protector.Unprotect(encryptedPassword);
}