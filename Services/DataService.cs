using System.Text.Json;

using PasswordManager.Models;

namespace PasswordManager.Services;

internal static class DataService
{
    private const string FilePath = "accounts.json";
    private static async Task Save(List<Account> accounts)
    {
        string json = JsonSerializer.Serialize(accounts, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        await File.WriteAllTextAsync(FilePath, json);
    }
    internal static async Task<List<Account>> Load()
    {
        if (!File.Exists(FilePath))
        {
            return [];
        }

        string json = await File.ReadAllTextAsync(FilePath);
        return JsonSerializer.Deserialize<List<Account>>(json) ?? [];
    }
    internal static async Task Add(Account account)
    {
        var accounts = await Load();
        accounts.Add(account);
        await Save(accounts);
    }
}