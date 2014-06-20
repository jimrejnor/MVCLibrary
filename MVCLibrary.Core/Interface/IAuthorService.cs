using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCLibrary.DAL.Models;
using MVCLibrary.Core.ViewModels;

namespace MVCLibrary.Core.Interface
{
    public interface IAuthorService
    {
        Author GetByID(int id);
        IEnumerable<Author> GetAll();

        bool Insert(Author author);
        bool Delete(int id);
        bool Update(Author authorToUpdate);

        // View Models
        AuthorViewModel GetAuthorViewByID(int id);
        AuthorListViewModel GetAuthorListView();

        void Dispose();
    }
}
