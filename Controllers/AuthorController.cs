using Microsoft.AspNetCore.Mvc;
using Bookish2.Models;
using Bookish2.Models.Requests;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bookish2.Services;

namespace Bookish2.Controllers;

[Route("authors")]

public class AuthorController : Controller
{
    private readonly ILogger <BooksController> _logger;
    private readonly AuthorService _authorService;

    public AuthorController(ILogger<BooksController> logger)
    {
        _logger = logger;
        _authorService = new AuthorService();
    }

    public IActionResult Index()
    {
        List<Author> authors = _authorService.GetAllAuthors().ToList();

        return View(authors);
    }

    [HttpPost("")]
    public IActionResult Create([FromForm] Author newAuthor)
    {
        Author createdAuthor = _authorService.Create(newAuthor);
        return RedirectToAction("Index");
    }

    [HttpGet("create")]
    public IActionResult CreateForm()
    {
        return View();
    }
}