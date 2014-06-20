using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCLibrary.DAL.Models;
using MVCLibrary.DAL.Interface;

namespace MVCLibrary.DAL.Repository
{
    public class TownRepository : GenericRepository<Town>, ITownRepository
    {
        public TownRepository(LibraryContext context)
            : base(context)
        {

        }
    }
}
