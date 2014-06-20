using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCLibrary.Core.ViewModels
{
    public class AuthorListViewModel
    {
        public IEnumerable<AuthorViewModel> Authors { get; set; }
    }
}
