namespace Bookish2.Models;

public class Book
{
    public int Id {get; set;}
    public string Title {get; set;}

    public List<Author> Authors {get; set;}

    public string Blurb {get; set;}

    public string ImageUrl {get; set;}

    public List<Copy>? Copies {get; set;}

    public List<Copy>? CheckedOutCopies {get; set;}
}