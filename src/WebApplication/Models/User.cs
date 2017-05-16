using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace WebApplication.Models
{
    public class User
    {
        
        [Key]
        public int id { get; set; }

        //[Required]

        [Display(Name ="First Name : ")]
        public string firstName { get; set; }

        [Display(Name = "Last Name : ")]
        public string lastName { get; set; }



        //[Required]
        [DataType(DataType.Date)]
        [Display(Name ="Birth Date :")]
        public DateTime birthDate { get; set; }

        //[Required]
        [Display(Name ="Login :")]
        public string login { get; set; }

        //[Required]
        [Display(Name ="Password :")]
        public string password { get; set; }

        //[Required]
        [Display(Name = "Confirm Password :")]
        [NotMapped]
        public string confirmPassword { get; set; }
        //[Required]
        [Display(Name = "Email :")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Display(AutoGenerateField =false)]
        public DateTime dateCreationAccount { get; set; }

        //[Required]
        [Display(Name = "Image :")]
        [DataType(DataType.ImageUrl)]
        public string image { get; set; } // A verifier !! 

        [Display(AutoGenerateField = false)]
        public int stateAccount { get; set; } // Pour avoir plus de liberté de choix

//        [Required]
        public string street { get; set; }
  //      [Required]
        public string city { get; set; }
    //    [Required]
        public string state { get; set; }
      //  [Required]
        //[MinLength(4,ErrorMessage ="This field is required and it must contain exactly 4 character")]
        //[Range(0,int.MaxValue)]
        public int postalCode { get; set; }
      //  [Required]
        public string country { get; set; }
        virtual public ICollection<Skill> skills { get; set; }
        virtual public ICollection<Certification> certifications { get; set; }
        virtual public ICollection<Formation> formations { get; set; }
       // virtual public ICollection<Notification> notifications { get; set; }
        virtual public ICollection<Reclamation> reclamations { get; set; }
       // virtual public ICollection<Offer> offers { get; set; }
        virtual public ICollection<Post> posts { get; set; }


        //Ce n'est pas la version finale.  

    }
}
