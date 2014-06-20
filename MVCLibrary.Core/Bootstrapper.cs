using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MVCLibrary.DAL.Models;
using MVCLibrary.Core;
using MVCLibrary.Core.ViewModels;

namespace MVCLibrary.Core
{
    public class BootStrapper
    {
        public static void ConfigureAutoMapper()
        {
            Mapper.CreateMap<Town, TownViewModel>();
            Mapper.CreateMap<Author, AuthorViewModel>()
                .ForMember(dto => dto.FullName, opt => opt.Ignore());
            Mapper.CreateMap<Book, BookViewModel>();

            // two-way
            Mapper.CreateMap<TownViewModel, Town>();
            Mapper.CreateMap<AuthorViewModel, Author>()
                .ForMember(dto => dto.FullName, opt => opt.Ignore());
            Mapper.CreateMap<BookViewModel, Book>();
             
        }
    }
}
