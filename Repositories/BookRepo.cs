using Bookish2.Models;
using Bookish2.Models.Requests;
using Microsoft.EntityFrameworkCore;

namespace Bookish2.Repositories
{
    public class BookRepo
    {
        private readonly Bookish2Context _context;

        public BookRepo()
        {
            _context = new Bookish2Context();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Books.Include(b=> b.Authors).Include(a => a.Copies).Include(c => c.CheckedOutCopies);
        }

        public Book GetById(int id)
        {
            return _context.Books.Include(b => b.Authors).Where(b => b.Id == id).Single();
        }

        public IEnumerable<Book> SearchByTitle(string query)
        {
            return _context.Books
                .Include(b => b.Authors)
                .Where(b => b.Title.Contains(query));
        }

        public Book Create(CreateBookRequest newBookRequest)
        {
           List<Author> newBookAuthors = new List<Author>();

            foreach (int authorId in newBookRequest.Authors)
            {
                Author author = _context.Authors.Where(a => a.Id == authorId).Single();

                newBookAuthors.Add(author);
            }

            Book newBook = new Book
            {
                Title = newBookRequest.Title,
                Blurb = newBookRequest.Blurb,
                ImageUrl = newBookRequest.ImageUrl,
                Authors = newBookAuthors
            };

            var addedBookEntity = _context.Books.Add(newBook);

            _context.SaveChanges();

            return addedBookEntity.Entity;
        }
    }
}