using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MVCLibrary.DAL.Models;

namespace MVCLibrary.Core.ViewModels
{
    public class BookViewModel
    {
        public int BookID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage="Book title must be between 5 and 50 characters")]
        public string Title { get; set; }

        public int AuthorID { get; set; }

        public virtual Author Author { get; set; }
    }
}
