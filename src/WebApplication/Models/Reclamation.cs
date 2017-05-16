using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication.Models
{
    public class Reclamation
    {
        [Key]
        public int? id { get; set; } //Nullable


      //  [Display(AutoGenerateField =false)]
     //   public TypeReclamation typeReclamation { get; set; }

        [Display(AutoGenerateField = false)]
        public bool state { get; set; }

        [Required]
        [Display(Name ="Description :")]
        [DataType(DataType.MultilineText)]
        public string description { get; set; }


        public Offer offer { get; set; }
        public Post post { get; set; }
        public User userReclam { get; set; }

     //   virtual public User userToReclam { get; set; }

    }
}
