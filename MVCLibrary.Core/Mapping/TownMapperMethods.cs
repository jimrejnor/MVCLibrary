using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCLibrary.Core.ViewModels;
using MVCLibrary.DAL.Models;
using AutoMapper;

namespace MVCLibrary.Core.Mapping
{
    public static class TownMapperMethods
    {
        public static TownViewModel ConvertToTownView(this Town town)
        {
            return Mapper.Map<Town, TownViewModel>(town);
        }

        public static IEnumerable<TownViewModel> ConvertToTownListView(this IEnumerable<Town> towns)
        {
            return Mapper.Map<IEnumerable<Town>, IEnumerable<TownViewModel>>(towns);
        }

        // ------------------------- BACK TO DOMAIN -------------------------------

        public static Town ConvertToDomain(this TownViewModel town)
        {
            return Mapper.Map<TownViewModel, Town>(town);
        }
    }
}
