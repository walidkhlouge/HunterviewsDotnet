using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApplication.Models

{ 
    [ComplexType]
    public class Address 
    {
        [Required]
        public string street { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public string state { get; set; }
        [Required]
        //[MinLength(4,ErrorMessage ="This field is required and it must contain exactly 4 character")]
        //[Range(0,int.MaxValue)]
        public int postalCode { get; set; }
        [Required]
        public string country { get; set; }
    }
}
