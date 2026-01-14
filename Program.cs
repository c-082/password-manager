using PasswordManager.Models;
using PasswordManager.Services;
var Accounts = DataService.Load();
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
            AddAccount();
            break;
        case '2':
            ViewAccounts();
            break;
        case '3':
            return;
        default:
            Console.WriteLine("Invalid input");
            continue;
    }
}
void AddAccount()
{
    Console.Write("Enter email: ");
    var email = Console.ReadLine();
    if (!ValidationService.IsValidEmail(email))
    {
        Console.WriteLine("Invalid email format");
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
        Email = email!,
        Site = site!,
        EncryptedPassword = encryptedPassword
    };
    DataService.Add(account);
    Console.WriteLine("Password added successfully");
}
void ViewAccounts()
{
    var accounts = DataService.Load();
    if (accounts.Count == 0)
    {
        Console.WriteLine("No accounts stored yet");
        return;
    }
    foreach (var acc in accounts)
        Console.WriteLine($"""
        Email: {acc.Email}
        Site: {acc.Site}
        Password: {PasswordService.Decrypt(acc.EncryptedPassword)}
        ---------------
        """);
}