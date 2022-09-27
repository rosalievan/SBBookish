namespace Bookish2.Models;

public class Copy
{
    public int Id {get; set;}

    public bool CheckedOut {get; set;}

    public Member? Member {get; set;}
}