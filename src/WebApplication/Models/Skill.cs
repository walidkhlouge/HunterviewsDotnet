using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Models
{
    public class Skill
    {

        [Key]
        public int ?id { get; set; } //Nullable
        
        [Required]
        [Display(Name ="Category :")]
        public Category category { get; set; }
        [Required]
        [Display(Name ="Name :")]
        public string name { get; set; }

        //[ForeignKey("userid")]
      //  public Nullable<int> userid { get; set; }

        //virtual public User user { get; set; }


    }
}
