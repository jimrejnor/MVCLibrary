using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCLibrary.Core.ViewModels
{
    public class AssignedTownDataViewModel
    {
        public int TownID { get; set; }
        public string Name { get; set; }
        public bool Assigned { get; set; }
    }
}
