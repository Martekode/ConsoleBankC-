// See https://aka.ms/new-console-template for more information
using ConsoleBankCSharp.Models;

static void Main()
{
    Client client = null;
    BankAccount bankAccount = null;
    Console.WriteLine("Hello dear (Potential) Customer!");
    Console.WriteLine("Would you like to register as a new Client? [yes / no]");
    string makeClientYesNo = Console.ReadLine();
    if (string.IsNullOrEmpty(makeClientYesNo))
    {
        Console.WriteLine($"{makeClientYesNo} was not a valid input! Please try again?");
        Console.WriteLine("Would you like to register as a new Client? [yes / no]");
        makeClientYesNo = Console.ReadLine();
    }

    switch (makeClientYesNo)
    {
        case "yes" or "y" or "Yes" or "1":
            Console.WriteLine("client is being made!");
            client = App.MakeClient();
            break;
        case "no":
            Console.WriteLine("Sorry to here that, have a nice day!");
            break;
    }

    if (client is not null)
    {
        Console.WriteLine($"Hello {client.name}.");
        Console.WriteLine("Do you want to make a bank account? [ yes / no ]");
        string chooseBankAccountYesNo = Console.ReadLine() ?? throw new InvalidOperationException();
        switch (chooseBankAccountYesNo)
        {
            case "yes" or "y" or "Yes" or "1":
                bankAccount = App.ChooseBankAccount(client);
                break;
            case "no" or "n" or "No" or "NO" or "2":
                Console.WriteLine("Sorry to hear that.");
                Console.WriteLine("No account was made!");
                break;
        }
    }

    if (bankAccount is not null)
    {
        // here comes interfacing with client
        // to fire off the withdraw or check account functions
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("__________________________________________");
        Console.WriteLine("|----------------------------------------|");
        Console.WriteLine("|----------Account Interfacing-----------|");
        Console.WriteLine("|----------------------------------------|");
        Console.WriteLine("__________________________________________");
        Console.ResetColor();
        Console.WriteLine("Action Options:");
        Console.WriteLine("Check Balance (1)");
        Console.WriteLine("Withdraw Funds (2)");
        Console.WriteLine("Deposit Funds (3)");
        Console.WriteLine("What would you like to do? [ 1 , 2 , 3 ]");
        string response = Console.ReadLine() ?? "1";
        
        //Actual switch to fire up the events
        switch (response)
        {
            case "1":
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Checking Balance...");
                int resBalance = bankAccount.CheckBalance();
                Console.WriteLine($"Your Balance: {resBalance}");
                break;
            case "2":
                //logic
                break;
            case "3":
                //logic
                break;
        }
    }
}
Main();