using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace WebApplication.Models
{
    public class JobSeeker : User
    {
        [Required]
        [Display(Name = "Name :")]
        public string name { get; set; }

        [Required]
        [Display(Name = "Domain :")]
        public string domain { get; set; }
        [Required]
        [Display(Name = "Years :")]
        public int years { get; set; }
    }
}
