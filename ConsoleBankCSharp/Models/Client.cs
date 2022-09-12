namespace ConsoleBankCSharp.Models;

public class Client
{
    private int Id { get; }
    private string Name { get; }= String.Empty;
    private DateTime Date_Joined { get; }

    public Client(int id, string name)
    {
        this.Id = id;
        this.Name = name;
        this.Date_Joined = new DateTime();
    }

}