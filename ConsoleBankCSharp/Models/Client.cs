namespace ConsoleBankCSharp.Models;

public class Client
{
    private int Id { get; set; }
    private string Name { get; set; }= String.Empty;
    private DateTime Date_Joined { get; set; }

    public Client(int id, string name)
    {
        this.Id = id;
        this.Name = name;
        this.Date_Joined = new DateTime();
    }

}