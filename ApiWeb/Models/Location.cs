using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.Models
{
    public class Location
    {
        [Key]
        public int Id_location { get; set; }
        public string Name { get; set; }
        public List<Animals> Animals {get; set;}

        public Region Region { get; set; }
    }
}
