using Bookish2.Models;
using Bookish2.Repositories;
using Bookish2.Models.Requests;
using Microsoft.EntityFrameworkCore;

namespace Bookish2.Services
{
    public class BookService
    {
        private readonly BookRepo _books;

        public BookService()
        {
            _books = new BookRepo();
        }
        public IEnumerable<Book> GetAllBooks()
        {
            return _books.GetAllBooks();
        }

        public Book GetById(int id)
        {
            return _books.GetById(id);
        }

        public IEnumerable<Book> SearchByTitle(string query)
        {
            return _books.SearchByTitle(query);
        }

        public Book Create(CreateBookRequest newBookRequest)
        {
           
           return _books.Create(newBookRequest);
        }
    }
}