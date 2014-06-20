using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MVCLibrary.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCLibrary.Core.ViewModels
{
    public class AuthorViewModel
    {

        public AuthorViewModel()
        {
            this.Towns = new HashSet<Town>();
            this.Books = new HashSet<Book>();
        }
        [Key]
        public int AuthorID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Author's first name must be between 3 and 30 characters")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Author's last name must be between 3 and 30 characters")]
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        public virtual ICollection<Town> Towns { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
