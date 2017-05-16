using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication.Models
{
    public class Notification
    {
        [Key]
        public int? id { get; set; } //Nullable

        [Display(AutoGenerateField =false)]
        public DateTime? date { get; set; }

        [Display(AutoGenerateField = false)]
        public TypeNotification? type { get; set; }

        [Display(AutoGenerateField = false)]
        public bool? seen { get; set; }

  //      [ForeignKey("userid")]
//        public Nullable<int> userid { get; set; }

     //   virtual public User user { get; set; }



    }
}
