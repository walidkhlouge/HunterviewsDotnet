using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Models
{
    public class Post
    {
        [Key]
        public int? id { get; set; } //Nullable

        [Display(AutoGenerateField = false)]
        public DateTime? date { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description :")]
        public string description { get; set; }
        //[ForeignKey("userid")]
       // public Nullable<int> userid { get; set; }
        //virtual public User user { get; set; }
        //[ForeignKey("offerid")]
        //public Nullable<int> offerid { get; set; }
        //virtual public Offer offer { get; set; }
    }
}
