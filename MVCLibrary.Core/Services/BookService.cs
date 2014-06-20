using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCLibrary.DAL;
using MVCLibrary.DAL.Models;
using MVCLibrary.DAL.Interface;
using MVCLibrary.Core.Interface;
using MVCLibrary.Core.ViewModels;
using MVCLibrary.Core.Mapping;

namespace MVCLibrary.Core.Services
{
    public class BookService : IBookService
    {
        private IUnitOfWork _unitOfWork;

        #region Constructor
        public BookService()
            : this(new UnitOfWork())
        { 
        }

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Service Functions
        public Book GetByID(int id)
        {
            return _unitOfWork.BookRepository.GetByID(id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _unitOfWork.BookRepository.GetAll();
        }

        public bool Insert(Book book)
        {
            try
            {
                _unitOfWork.BookRepository.Insert(book);
                _unitOfWork.Save();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool Delete(int id)
        {
            try
            {
                _unitOfWork.BookRepository.Delete(id);
                _unitOfWork.Save();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool Update(Book bookToUpdate)
        {
            try
            {
                _unitOfWork.BookRepository.Update(bookToUpdate);
                _unitOfWork.Save();
            }
            catch 
            {
                return false;
            }

            return true;
        }
        #endregion

        #region ViewModel methods
        public BookViewModel GetBookViewByID(int id)
        {
            Book book = GetByID(id);

            return book.ConvertToBookView();
        }

        public BookListViewModel GetBookListView()
        {
            IEnumerable<Book> allBooks = GetAll();

            return new BookListViewModel
            {
                Books = allBooks.ConvertToBookListView()
            };
        }
        #endregion

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
