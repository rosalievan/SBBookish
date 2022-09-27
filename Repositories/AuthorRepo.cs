using Bookish2.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookish2.Repositories
{
    public class AuthorRepo
    {
        private readonly Bookish2Context _context;

        public AuthorRepo()
        {
            _context = new Bookish2Context();
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _context.Authors.Include(b=> b.Books);
        }

        public Author GetById(int id)
        {
            return _context.Authors.Include(b => b.Books).Where(b => b.Id == id).Single();
        }

        public IEnumerable<Author> SearchByName(string query)
        {
            return _context.Authors
                .Include(b => b.Books)
                .Where(b => b.Name.Contains(query));
        }

        public Author Create(Author newAuthor)
        {
           var addedAuthorEntity = _context.Authors.Add(newAuthor);
           _context.SaveChanges();

           return addedAuthorEntity.Entity;
        }
    }
}