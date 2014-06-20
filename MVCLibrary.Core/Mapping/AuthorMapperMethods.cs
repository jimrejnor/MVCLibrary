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
    public static class AuthorMapperMethods
    {
        public static AuthorViewModel ConvertToAuthorView(this Author author)
        {
            return Mapper.Map<Author, AuthorViewModel>(author);
        }

        public static IEnumerable<AuthorViewModel> ConvertToAuthorListView(this IEnumerable<Author> authors)
        {
            return Mapper.Map<IEnumerable<Author>, IEnumerable<AuthorViewModel>>(authors);
        }

        // ------------------------- BACK TO DOMAIN -------------------------------

        public static Author ConvertToDomain(this AuthorViewModel author)
        {
            return Mapper.Map<AuthorViewModel, Author>(author);
        }
    }
}
