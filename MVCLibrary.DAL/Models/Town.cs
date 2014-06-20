//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCLibrary.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    public partial class Town
    {
        public Town()
        {
            this.Authors = new HashSet<Author>();
        }
        [Key]
        public int TownID { get; set; }

        [Required]
        [Display(Name = "Town")]
        public string Name { get; set; }

        public virtual ICollection<Author> Authors { get; set; }
    }
}