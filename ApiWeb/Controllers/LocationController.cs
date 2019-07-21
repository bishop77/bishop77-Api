using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiWeb.Controllers
{
    [Route("[controller]/[action]")]
    public class LocationController : BaseApiController<Location>
    {
        public LocationController(CreateContextModel contextModel) : base(contextModel){ }

        [HttpPost]
        public async Task<IActionResult> AddLocation([FromBody]Location obj)
        {
            Region region = db.Regions.FirstOrDefault(x => x.Id_region == obj.Region.Id_region);
            return await base.Add(new Location { Name = obj.Name, Region = region });
        }
        [HttpPut]
        public async Task<IActionResult> UpdateLocation([FromBody]Location obj)
        {
            if (obj == null)
                BadRequest();
            if (!entity.Any(x => x.Id_location == obj.Id_location))
                return NotFound();
            obj.Region = db.Regions.FirstOrDefault(x => x.Id_region == obj.Region.Id_region);
            return await base.Update(obj);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveLocation([FromBody]int id)
        {
            return await base.Remove(entity.FirstOrDefault(x => x.Id_location == id));
        }
        [HttpGet]
        public async Task<IEnumerable<Location>> GetLocation()
        {
           return await entity.Include(p=> p.Region).ToListAsync();
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