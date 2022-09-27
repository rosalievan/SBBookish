using Bookish2.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookish2
{
    public class Bookish2Context: DbContext
    {
        public DbSet<Book> Books {get; set;}

        public DbSet<Copy> Copies{get; set;}
        public DbSet<Author> Authors {get; set;}

        public DbSet<Member> Members {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            // This is the configuration used for connecting to the database
            optionsBuilder.UseNpgsql(@"Server=localhost;Port=5432;Database=bookish2;User Id=bookish2;Password=bookish2;");
        }
    }
}