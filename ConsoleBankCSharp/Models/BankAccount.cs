namespace ConsoleBankCSharp.Models;
public enum Type {
    CheckingsAccount,
    SavingsAccount,
    CreditAccount
}
public class BankAccount
{
    public Client client;
    public int Balance = 0;
    public Type type;

    public BankAccount(Client inputClient, int initDeposit,int initType)
    {
        this.client = inputClient;
        this.Balance += initDeposit;
        this.type = TypeValidation(initType);
    }
    
    private static Type TypeValidation(int input) 
    {
        Type rtrn;
        if (input == 1)
        {
            return rtrn = Type.CheckingsAccount;
        }else if (input == 2)
        {
            return rtrn = Type.SavingsAccount;
        }else if (input == 3)
        {
            return rtrn = Type.CreditAccount;
        }
        else
        {
            return rtrn = Type.CheckingsAccount;
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