using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication.Models
{
    public class Evaluation
    {
        [Key]
        public int? id { get; set; }

        [Required]
        public double mark { get; set; }

        public DateTime? date { get; set; }
 
      //  virtual public Offer offer { get; set; }
    }
}
