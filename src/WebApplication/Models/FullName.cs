using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Models
{
    [ComplexType]
    public class FullName
    {
        public string firstName { get; set; }
        public string lastName { get; set; }

    }
}
