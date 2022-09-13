namespace ConsoleBankCSharp.Models;

public sealed class App
{
    private static readonly App instance = new App();

    static App()
    {
    }

    private App()
    {
    }

    public static App Instance
    {
        get
        {
            return instance;
        }
    }

    private static string EnterName()
    {
        Console.WriteLine("Please give enter your name:");
        string response = Console.ReadLine();
        if (!String.IsNullOrEmpty(response))
        {
            return response;
        }
        else
        {
            Console.WriteLine($"Please fill in your name!!");
            response = EnterName();
        }
        return response;
    }
    public static Client MakeClient()
    {
        Random rnd = new Random();
        int id = rnd.Next();
        string responseName = EnterName();
        Client client = new Client(id, responseName);
        return client;
    }

    public static BankAccount ChooseBankAccount(Client client)
    {
        Console.WriteLine($"Hello {client.name}, what type of account do you want to make?");
        Console.WriteLine("There are 3 kind of accounts;");
        Console.WriteLine("1: Checking Account");
        Console.WriteLine("This account is regular with non-negative balance and deposit/withdraw rights");
        Console.WriteLine("2: Saving Account");
        Console.WriteLine("This account only has deposit rights. To withdraw funds, contact ous via mail or via cell: 0478643605");
        Console.WriteLine("3: Credit Account");
        Console.WriteLine("This account has all the checking account rights,");
        Console.WriteLine(" but also can go up to 2500 euro's negative");
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine("Make your choice! [ 1 , 2 , 3]");
        int InitType = Int32.Parse(Console.ReadLine() ?? "1");
        Console.WriteLine("Now enter a minimum deposit of 10€");
        int InitDeposit = Int32.Parse(Console.ReadLine() ?? "10");
        BankAccount bankAccount = new BankAccount(client , InitDeposit, InitType );
        Console.WriteLine($"{client.name}, your bank account was successfully set up");
        return bankAccount;
    }
}