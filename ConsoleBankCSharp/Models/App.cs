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

    public Client MakeClient(int id , string name)
    {
        Client client = new Client(id, name);
        return client;
    }

    public BankAccount ChooseBankAccount(Client client, int InitDeposit , int InitType )
    {
        BankAccount bankAccount = new BankAccount(client , InitDeposit, InitType );
        return bankAccount;
    }
}