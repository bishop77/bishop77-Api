using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiWeb.Controllers
{
    [Route("[controller]/[action]")]
    public class ValuesController : BaseApiController<Animals>
    {
        public ValuesController(CreateContextModel contextModel) : base(contextModel){ }

        [HttpPost]
        public async Task<IActionResult> AddAnimals(string Name, int id_leather, int id_location)
        {
            Location location = db.Locations.FirstOrDefault(x => x.Id_location== id_location);
            Leather leather = db.Leathers.FirstOrDefault(x => x.Id_leather == id_leather);
            return await base.Add(new Animals { Name = Name, Location = location, Leather = leather });
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAnimals(Animals obj)
        {
            if (obj == null)
                BadRequest();
            if (!entity.Any(x => x.Id_animal == obj.Id_animal))
                return NotFound();
            return await base.Update(obj);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAnimals(int id)
        {
            return await base.Remove(entity.FirstOrDefault(x => x.Id_animal == id));
        }
        [HttpGet]
        public IEnumerable<Animals> GetAnimals()
        {
            return entity.ToList();
        }
        [HttpGet]
        public IActionResult GetAnimalsById(int id)
        {
            Animals Animals = entity.FirstOrDefault(x => x.Id_animal == id);
            if (Animals == null)
                return NotFound();
            return new ObjectResult(Animals);
        }
    }
}
