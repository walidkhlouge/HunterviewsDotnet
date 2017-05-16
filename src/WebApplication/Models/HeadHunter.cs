using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class HeadHunter : User  
    {
        [Required]
        [Display(Name = "Name :")]
        public string name { get; set; }

        [Required]
        [Display(Name = "Domain :")]
        public string domain { get; set; }
    }
}
