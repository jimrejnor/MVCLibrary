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
    public class TownService : ITownService
    {
        private IUnitOfWork _unitOfWork;

        #region Constructor
        public TownService()
            : this(new UnitOfWork())
        { 
        }

        public TownService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Service Functions
        public Town GetByID(int id)
        {
            return _unitOfWork.TownRepository.GetByID(id);
        }

        public IEnumerable<Town> GetAll()
        {
            return _unitOfWork.TownRepository.GetAll();
        }

        public bool Insert(Town town)
        {
            try
            {
                _unitOfWork.TownRepository.Insert(town);
                _unitOfWork.Save();
            }
            catch
            {
                return false;
            }
            System.Diagnostics.Debug.WriteLine("SomeText");

            return true;
        }

        public bool Delete(int id)
        {
            try
            {
                _unitOfWork.TownRepository.Delete(id);
                _unitOfWork.Save();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool Update(Town townToUpdate)
        {
            try
            {
                _unitOfWork.TownRepository.Update(townToUpdate);
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
        public TownViewModel GetTownViewByID(int id)
        {
            Town town = GetByID(id);

            return town.ConvertToTownView();
        }

        public TownListViewModel GetTownListView()
        {
            IEnumerable<Town> allTowns = GetAll();

            return new TownListViewModel 
            {
                Towns = allTowns.ConvertToTownListView()
            };
        }

        //public int NumberOfAuthorsInTown(TownListViewModel townListView)
        //{
        //    foreach (TownViewModel town in TownListViewModel)
        //    {
        //        town.NumberOfAuthors = 
        //    }
        //    return town.Authors.Count();
        //}
        #endregion

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
