using Bookish2.Models;
using Bookish2.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bookish2.Services
{
    public class AuthorService
    {
        private readonly AuthorRepo _authors;

        public AuthorService()
        {
            _authors = new AuthorRepo();
        }
        public IEnumerable<Author> GetAllAuthors()
        {
            return _authors.GetAllAuthors();
        }

        public Author GetById(int id)
        {
            return _authors.GetById(id);
        }

        public IEnumerable<Author> SearchByName(string query)
        {
            return _authors.SearchByName(query);
        }

        public Author Create(Author newAuthor)
        {
           return _authors.Create(newAuthor);
        }
    }
}