using System.Text.Json;
using PasswordManager.Models;
namespace PasswordManager.Services;

static class DataService
{
    private const string FilePath = "accounts.json";
    public static List<Account> Load()
    {
        if (!File.Exists(FilePath))
            return [];
        string json = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<List<Account>>(json) ?? [];
    }
    private static void Save(List<Account> accounts)
    {
        string json = JsonSerializer.Serialize(accounts, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(FilePath, json);
    }
    public static void Add(Account account)
    {
        var accounts = Load();
        accounts.Add(account);
        Save(accounts);
    }
}