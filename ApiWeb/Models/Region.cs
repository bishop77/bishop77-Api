using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.Models
{
    public class Region
    {
        [Key]
        public int Id_region { get; set; }
        public string Name { get; set; }
        public List<Location> Locations { get; set; }
    }
}
