using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Newsmail
    {
        [Key]
        public int id { get; set; }
        [Required,EmailAddress]
        [Display(Name = "From :")]
        public string from { get; set; }
        
        [Display(Name = "To :")]
        public string to { get; set; }
        [Required]
        [Display(Name = "Subject :")]
        public string subject;
        [Required]
        [Display(Name = "Message :")]
        public string messag { get; set; }



    }
}
