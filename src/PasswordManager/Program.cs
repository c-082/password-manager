using PasswordManager.Models;
using PasswordManager.Services;

Console.WriteLine("""
                ================
=============== PASSWORD MANAGER ===============
                ================
""");
while (true)
{
    Console.WriteLine("""
        1. Add an account
        2. View accounts
        3. Exit
    """);
    Console.Write("Choose: ");
    char choice = Console.ReadKey().KeyChar;
    Console.WriteLine();
    switch (choice)
    {
        case '1':
            await AddAccount();
            break;
        case '2':
            await ViewAccounts();
            break;
        case '3':
            return;
        default:
            Console.WriteLine("Invalid input");
            continue;
    }
}
async Task AddAccount()
{
    Console.Write("Enter username: ");
    var username = Console.ReadLine();
    if (!ValidationService.IsValidUsername(username))
    {
        Console.WriteLine("Username is either too long or empty");
        return;
    }
    Console.Write("Enter site: ");
    var site = Console.ReadLine();
    if (!ValidationService.IsValidSite(site))
    {
        Console.WriteLine("Site is either too long or empty");
        return;
    }
    Console.Write("Enter password: ");
    var password = Console.ReadLine();
    if (!ValidationService.IsValidPassword(password))
    {
        Console.WriteLine("Password is either too long or empty");
        return;
    }
    var encryptedPassword = PasswordService.Encrypt(password!);
    Account account = new()
    {
        Username = username!,
        Site = site!,
        EncryptedPassword = encryptedPassword
    };
    await DataService.Add(account);
    Console.WriteLine("Password added successfully");
}
async Task ViewAccounts()
{
    var accounts = await DataService.Load();
    if (accounts.Count == 0)
    {
        Console.WriteLine("No accounts stored yet");
        return;
    }
    foreach (var acc in accounts)
    {
        Console.WriteLine($"""
        Username: {acc.Username}
        Site: {acc.Site}
        Password: {PasswordService.Decrypt(acc.EncryptedPassword)}
        ---------------
        """);
    }
}