using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ApiWeb.Models
{
    public class Leather
    {
        [Key]
        public int Id_leather { get; set; }
        public string Name { get; set; }
    }
}
