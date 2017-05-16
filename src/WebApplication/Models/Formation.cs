using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace WebApplication.Models
{
    public class Formation
    {

        [Key]
        public int? id { get; set; }

        [Required]
        [Display(Name ="Ecole")]
        public string ecole { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name="Date Start")]
        public DateTime dateStart { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date Start")]
        public DateTime dateEnd { get; set; }

        [ForeignKey("userid")]
        public Nullable<int> userid { get; set; }

        //Relation with "user" class
        
        virtual public User user { get; set; }

    }
}
