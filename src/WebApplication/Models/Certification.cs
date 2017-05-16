using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication.Models
{
    public class Certification
    {
        [Key]
        public int? id { get; set; } // Nullable

        [Required]
        [Display(Name ="Title :")]
        public string title { get; set; }

        [Display(Name ="Center :")]
        public Centre centre { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date :")]
        public DateTime dateStart { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "End Date :")]
        public DateTime dateEnd { get; set; }
        
         public virtual User user { get; set; }


    }
}
