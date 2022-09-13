// See https://aka.ms/new-console-template for more information
using ConsoleBankCSharp.Models;

static void Main()
{
    Client client = null;
    BankAccount bankAccount;
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
}
Main();