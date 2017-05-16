using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{

    public class Coordonates
    {
        [Key]
        public int? id { get; set; } // Nullable
        [Required]
        [Display(Name = "longitude :")]
        public double lon { get; set; }
        [Required]
        [Display(Name = "latitude :")]
        public double lat { get; set; }
    }
}
