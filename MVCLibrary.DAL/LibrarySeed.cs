using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MVCLibrary.DAL.Models;

namespace MVCLibrary.DAL
{
    public class LibrarySeed : DropCreateDatabaseIfModelChanges<LibraryContext>
    {
        protected override void Seed(LibraryContext context)
        {
            //base.Seed(context);

            var towns = new List<Town>
            {
                new Town { Name = "Osijek" },
                new Town { Name = "Zagreb" },
                new Town { Name = "Županja" },
                new Town { Name = "Split" },
                new Town { Name = "Vinkovci" },
                new Town { Name = "Makarska" }
            };
            towns.ForEach(t => context.Towns.Add(t));
            context.SaveChanges();

            var authors = new List<Author>
            {
                new Author { FirstName = "Ivo", LastName = "Ivić" },
                new Author { FirstName = "Pero", LastName = "Perić" },
                new Author { FirstName = "Bruno", LastName = "Brunić" },
                new Author { FirstName = "Saša", LastName = "Matić" },
                new Author { FirstName = "Zgembo", LastName = "Adišlić" }
            };
            authors.ForEach(a => context.Authors.Add(a));
            context.SaveChanges();

            var books = new List<Book>
            {
                new Book { Title = "Naslov1" },
                new Book { Title = "Naslov2" },
                new Book { Title = "Naslov3" },
                new Book { Title = "Naslov4" },
                new Book { Title = "Naslov5" },
            };
            books.ForEach(b => context.Books.Add(b));
            context.SaveChanges();
            
        }
    }
}
