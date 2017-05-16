using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WebApplication.Models
{
    public class Entreprise : ComplexTypeAttribute
    {
        [Required]
        [Display(Name ="Name :")]
        public string name { get; set; }

        [Required]
        [Display(Name = "Domain :")]
        public string domain { get; set; }

    }
}
