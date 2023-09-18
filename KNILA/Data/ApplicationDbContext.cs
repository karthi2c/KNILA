using KNILA.Models;
using Microsoft.EntityFrameworkCore;

namespace KNILA.Data
{
    public class ApplicationDbContext :DbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
                
        }


         public DbSet<Book>  Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book {BookId=1, Publisher = "ABC Publisher", Title = "Ponniyin Selvan", AuthorFirstName = "Kalki", AuthorLastName = "KrishnaMoorthy", Price = 500 });
        }
    }
}
