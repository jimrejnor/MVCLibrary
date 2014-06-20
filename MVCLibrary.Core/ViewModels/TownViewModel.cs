using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MVCLibrary.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCLibrary.Core.ViewModels
{
    public class TownViewModel
    {
         public TownViewModel()
        {
            this.Authors = new HashSet<Author>();
        }
        [Key]
        public int TownID { get; set; }

        [DisplayName("Town")]
        public string Name { get; set; }

        public virtual ICollection<Author> Authors { get; set; }
    }
}
