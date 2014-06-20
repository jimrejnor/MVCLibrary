using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCLibrary.DAL.Models;

namespace MVCLibrary.DAL.Interface
{
   public interface IUnitOfWork 
    {
       LibraryContext Context { get; set; }

       IGenericRepository<Town> TownRepository { get; }
       IGenericRepository<Author> AuthorRepository { get; }
       IGenericRepository<Book> BookRepository { get; }

       void Save();
       void Dispose();
    }
}
