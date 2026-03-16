using System.Text.Json;

using PasswordManager.Models;

namespace PasswordManager.Services;

static class DataService
{
    private const string FilePath = "accounts.json";
    private static readonly JsonSerializerOptions Options = new()
    {
        WriteIndented = true,
        IndentSize = 4
    };

    static DataService()
    {
        if (!File.Exists(FilePath) || File.ReadAllText(FilePath) == string.Empty)
        {
            Save([]).Wait();
        }
    }
    private static async Task Save(List<Account> accounts)
    {
        string json = JsonSerializer.Serialize(accounts, Options);
        await File.WriteAllTextAsync(FilePath, json);
    }
    public static async Task<List<Account>> Load()
    {
        if (!File.Exists(FilePath))
        {
            return [];
        }
        string json = await File.ReadAllTextAsync(FilePath);
        return JsonSerializer.Deserialize<List<Account>>(json) ?? [];
    }
    public static async Task Add(Account account)
    {
        var accounts = await Load();
        accounts.Add(account);
        await Save(accounts);
    }
}