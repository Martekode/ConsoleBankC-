using System.Diagnostics;

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

    public static void WithdrawFunds(BankAccount bankAccount)
    {
        Console.WriteLine("How much do you want to withdraw");
        string responseString = Console.ReadLine() ?? "0";
        int response = Int32.Parse(responseString);     
        if (response < 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("that's a negative amount, please enter a positive amount to withdraw");
            Console.ResetColor();
            WithdrawFunds(bankAccount);
            return;
        }else if (response == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The amount you gave was 0... Please don't waste my time!!");
            Console.ResetColor();
            WithdrawFunds(bankAccount);
            return;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            bankAccount.WithDraw(response);
            Console.WriteLine($"{bankAccount.Client.name}, your balance is now: {bankAccount.CheckBalance()}");
            Console.ResetColor();
        }
    }
    private static string EnterName()
    {
        Console.WriteLine("Please enter your name:");
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
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Hello {client.name}, what type of account do you want to make?");
        Console.WriteLine("There are 3 kind of accounts;");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("1: Checking Account");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("This account is regular with non-negative balance and deposit/withdraw rights");
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("2: Saving Account");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("This account only has deposit rights. To withdraw funds, contact ous via mail or via cell: 0478643605");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("3: Credit Account");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("This account has all the checking account rights,");
        Console.WriteLine(" but also can go up to 2500 euro's negative");
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine("Make your choice! [ 1 , 2 , 3]");
        int InitType = Int32.Parse(Console.ReadLine() ?? "1");
        Console.WriteLine("Now enter a minimum deposit of 10 euro's.");
        Console.WriteLine("If u enter less then 10, it will default to 10 euro's.");
        int InitDeposit = Int32.Parse(Console.ReadLine() ?? "10");
        if (InitDeposit < 10 && InitDeposit > 0)
        {
            InitDeposit = 10;
        }
        BankAccount bankAccount = new BankAccount(client , InitDeposit, InitType );
        Console.WriteLine($"{client.name}, your bank account was successfully set up");
        return bankAccount;
    }

    public static void AccountInterfacing(string input , BankAccount bankAcc)
    {
        switch (input)
        {
            case "1":
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Checking Balance...");
                int resBalance = bankAcc.CheckBalance();
                Console.WriteLine($"Your Balance: {resBalance} €");
                Console.ResetColor();
                break;
            case "2":
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Let's start the withdraw!");
                WithdrawFunds(bankAcc);
                break;
            case "3":
                //logic
                break;
        }
    }
}