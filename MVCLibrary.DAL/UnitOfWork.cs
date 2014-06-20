using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCLibrary.DAL.Interface;
using MVCLibrary.DAL.Repository;
using MVCLibrary.DAL.Models;

namespace MVCLibrary.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        public LibraryContext Context { get; set; }

        private IGenericRepository<Author> _authorRepository;
        private IGenericRepository<Town> _townRepository;
        private IGenericRepository<Book> _bookRepository;

        #region Constructors

        public UnitOfWork(LibraryContext context)
        {
            Context = context;
        } 

        public UnitOfWork()
        {
            if (Context == null)
            {
                Context = new LibraryContext();
                //Context.Configuration.ProxyCreationEnabled = false;
            }
        }
        #endregion


        #region Instance Variable Setters
        public IGenericRepository<Author> AuthorRepository
        {
            get
            {
                if (_authorRepository == null)
                {
                    _authorRepository = new AuthorRepository(Context);
                }
                return _authorRepository;
            }
        }

        public IGenericRepository<Town> TownRepository
        {
            get
            {
                if (_townRepository == null)
                {
                    _townRepository = new TownRepository(Context);
                }
                return _townRepository;
            }
        }

        public IGenericRepository<Book> BookRepository
        {
            get
            {
                if (_bookRepository == null)
                {
                    _bookRepository = new BookRepository(Context);
                }
                return _bookRepository;
            }
        }
        #endregion

        public void Save()
        {
            Context.SaveChanges();
        }

        #region Dispose
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
