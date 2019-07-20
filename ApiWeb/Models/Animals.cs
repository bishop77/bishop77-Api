using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.Models
{
    public class Animals
    {
        [Key]
        public int Id_animal { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        public Leather Leather{ get; set; }
        public Location Location { get; set; }
    }
}
