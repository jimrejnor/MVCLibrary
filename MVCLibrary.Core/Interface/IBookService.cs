using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCLibrary.DAL.Models;
using MVCLibrary.Core.ViewModels;

namespace MVCLibrary.Core.Interface
{
    public interface IBookService
    {
        Book GetByID(int id);
        IEnumerable<Book> GetAll();

        bool Insert(Book author);
        bool Delete(int id);
        bool Update(Book bookToUpdate);

        // View Model
        BookViewModel GetBookViewByID(int id);
        BookListViewModel GetBookListView();

        void Dispose();
    }
}
