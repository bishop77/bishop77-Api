using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiWeb.Controllers
{
    [Route("[controller]/[action]")]
    public class LocationController : BaseApiController<Location>
    {
        public LocationController(CreateContextModel contextModel) : base(contextModel){ }

        [HttpPost]
        public async Task<IActionResult> AddLether(string Name, int id_region)
        {
            Region region = db.Regions.FirstOrDefault(x => x.Id_region == id_region);
            return await base.Add(new Location { Name = Name, Region = region });
        }
        [HttpPut]
        public async Task<IActionResult> UpdateLether(Location obj)
        {
            if (obj == null)
                BadRequest();
            if (!entity.Any(x => x.Id_location == obj.Id_location))
                return NotFound();
            return await base.Update(obj);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveLether(int id)
        {
            return await base.Remove(entity.FirstOrDefault(x => x.Id_location == id));
        }
        [HttpGet]
        public IEnumerable<Location> GetLocation()
        {
            return entity.ToList();
        }
        [HttpGet]
        public IActionResult GetLocationById(int id)
        {
            Location Location = entity.FirstOrDefault(x => x.Id_location == id);
            if (Location == null)
                return NotFound();
            return new ObjectResult(Location);
        }

    }
}