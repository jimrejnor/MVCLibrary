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
    public static class BookMapperMethods
    {
        public static BookViewModel ConvertToBookView(this Book book)
        {
            return Mapper.Map<Book, BookViewModel>(book);
        }

        public static IEnumerable<BookViewModel> ConvertToBookListView(this IEnumerable<Book> books)
        {
            return Mapper.Map<IEnumerable<Book>, IEnumerable<BookViewModel>>(books);
        }

        // ------------------------- BACK TO DOMAIN -------------------------------

        public static Book ConvertToDomain(this BookViewModel book)
        {
            return Mapper.Map<BookViewModel, Book>(book);
        }
    }
}