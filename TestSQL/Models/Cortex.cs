using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestSQL.Models
{
    public class Cortex
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string catchphrase { get; set; }
        public int age { get; set; }
    }
}
