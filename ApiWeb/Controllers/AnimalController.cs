using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiWeb.Controllers
{
    [Route("[controller]/[action]")]
    public class AnimalController : BaseApiController<Animals>
    {
        public AnimalController(CreateContextModel contextModel) : base(contextModel){ }

        [HttpPost]
        public async Task<IActionResult> AddAnimals([FromBody] Animals obj)
        {
            Location location = db.Locations.FirstOrDefault(x => x.Id_location== obj.Location.Id_location);
            Leather leather = db.Leathers.FirstOrDefault(x => x.Id_leather == obj.Leather.Id_leather);
            obj.Location = location;
            obj.Leather = leather;
            return await base.Add(obj);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAnimals([FromBody]Animals obj)
        {
            if (obj == null)
                BadRequest();
            if (!entity.Any(x => x.Id_animal == obj.Id_animal))
                return NotFound();
            Leather leather = db.Leathers.FirstOrDefault(x => x.Id_leather == obj.Leather.Id_leather);
            Location location = db.Locations.FirstOrDefault(x => x.Id_location== obj.Location.Id_location);
            obj.Location = location;
            obj.Leather = leather;
            return await base.Update(obj);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveAnimals([FromBody]int id)
        {
            return await base.Remove(entity.FirstOrDefault(x => x.Id_animal == id));
        }
        [HttpGet]
        public IEnumerable<Animals> GetAnimals()
        {
            return entity.Include(p => p.Location).Include(p=> p.Leather).ToList();
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
