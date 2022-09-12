namespace ConsoleBankCSharp.Models;
public enum Type {
    CheckingsAccount,
    SavingsAccount,
    CreditAccount
}
public class BankAccount
{
    private Client client;
    private int Balance = 0;
    private Type type;

    public BankAccount(Client inputClient, int initDeposit,int initType)
    {
        this.client = inputClient;
        this.Balance += initDeposit;
        TypeValidation(initType);
    }
    
    private void TypeValidation(int input) 
    {
        switch (input)
        {
            case 1 :
                this.type = Type.CheckingsAccount;
                break;
            case 2 :
                this.type = Type.SavingsAccount;
                break;
            case 3 :
                this.type = Type.CreditAccount;
                break;
        }
    }

    public int CheckBalance()
    {
        return this.Balance;
    }

    public void WithDraw(int input)
    {
        if (this.type == Type.CheckingsAccount && this.Balance > 0 && this.Balance >= input)
        {
            this.Balance -= input;
            Console.WriteLine($"{input} Has been withdrawn.");
        }
        else if (this.type == Type.SavingsAccount)
        {
            Console.WriteLine($"You have set boundaries on withdrawing money from" +
                              $"your savings Account. {input} was not withdrawn, contact" +
                              $" bank for more info.");
        }
        else if (this.type == Type.CreditAccount && (this.Balance - input) > -2500)
        {
            this.Balance -= input;
            Console.WriteLine($"{input} Has been withdrawn!!");
        }
        else
        {
            Console.WriteLine($"insufficient funds to withdraw {input}");
        }
    }

    public void Deposit(int input)
    {
        if (input > 0)
        {
            this.Balance += input;
            Console.WriteLine($"{input} Has been deposited onto your account");  
        }
        else
        {
            Console.WriteLine($"{input} is not a valid deposit value!");
        }
    }
}