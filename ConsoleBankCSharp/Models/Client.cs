namespace ConsoleBankCSharp.Models;

public class Client
{
    private int _Id { get; set; }
    public int id => _Id;
    private string _Name { get; }
    public string name => _Name;
    private DateTime _Date_Joined { get; }
    public DateTime date_joined => _Date_Joined;
    public Client(int id, string name)
    {
        _Id = id;
        _Name = name;
        _Date_Joined = new DateTime();
    }

}