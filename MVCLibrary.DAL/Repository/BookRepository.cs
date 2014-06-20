using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCLibrary.DAL.Models;
using MVCLibrary.DAL.Interface;

namespace MVCLibrary.DAL.Repository
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(LibraryContext context)
            : base(context)
        {

        }
    }
}
