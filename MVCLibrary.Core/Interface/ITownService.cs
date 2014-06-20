using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCLibrary.DAL.Models;
using MVCLibrary.Core.ViewModels;

namespace MVCLibrary.Core.Interface
{
    public interface ITownService
    {
        Town GetByID(int id);
        IEnumerable<Town> GetAll();

        bool Insert(Town author);
        bool Delete(int id);
        bool Update(Town townToUpdate);

        // View Models
        TownViewModel GetTownViewByID(int id);
        TownListViewModel GetTownListView();

        void Dispose();
    }
}
