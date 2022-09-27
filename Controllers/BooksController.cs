using Microsoft.AspNetCore.Mvc;
using Bookish2.Models;
using Bookish2.Models.Requests;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bookish2.Services;

namespace Bookish2.Controllers;

[Route("Book")]
public class BooksController : Controller
{
    private readonly ILogger<BooksController> _logger;
    private readonly BookService _bookService;
    private readonly AuthorService _authorService;

    public BooksController(ILogger<BooksController> logger)
    {
        _logger = logger;
        _authorService = new AuthorService();
        _bookService = new BookService();
    }

    public IActionResult Index()
    {
        
        List<Book> books = _bookService.GetAllBooks().ToList();
        return View(books);
    }

    [HttpPost("")]
    public IActionResult Create([FromForm] CreateBookRequest newBookRequest)
    {
        Book createdBook = _bookService.Create(newBookRequest);

        return RedirectToAction("Index");
    }

    [HttpGet("create")]
    public IActionResult CreateForm()
    {
        List<Author> authors = _authorService.GetAllAuthors().ToList();
        List<SelectListItem> selectListAuthors = 
            authors.Select(
                a=> new SelectListItem {Value = a.Id.ToString(), Text = a.Name}
            )
            .ToList();
        
        ViewBag.Authors = selectListAuthors;

        return View();
    }

}
