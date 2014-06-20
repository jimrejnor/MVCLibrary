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
    public class AuthorService : IAuthorService
    {
        private IUnitOfWork _unitOfWork;

        #region Constructor
        public AuthorService()
            : this(new UnitOfWork())
        { 
        }

        public AuthorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Service Functions
        public Author GetByID(int id)
        {
            return _unitOfWork.AuthorRepository.GetByID(id);
        }

        public IEnumerable<Author> GetAll()
        {
            return _unitOfWork.AuthorRepository.GetAll();
        }

        public bool Insert(Author author)
        {
            try
            {
                // testing non working many-many town-author add
                //Town town = _unitOfWork.TownRepository.GetByID(4);
                //author.Towns.Add(town);

                _unitOfWork.AuthorRepository.Insert(author);
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
                _unitOfWork.AuthorRepository.Delete(id);
                _unitOfWork.Save();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool Update(Author authorToUpdate)
        {
            try
            {
                _unitOfWork.AuthorRepository.Update(authorToUpdate);
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
        public AuthorViewModel GetAuthorViewByID(int id)
        {
            Author author = GetByID(id);

            return author.ConvertToAuthorView();
        }

        public AuthorListViewModel GetAuthorListView()
        {
            IEnumerable<Author> allAuthors = GetAll();

            return new AuthorListViewModel
            {
                Authors = allAuthors.ConvertToAuthorListView()
            };
        }
        #endregion

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
