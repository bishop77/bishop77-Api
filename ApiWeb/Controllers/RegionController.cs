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
    public class RegionController : BaseApiController<Region>
    {
        public RegionController(CreateContextModel contextModel) : base(contextModel){ }

        [HttpPost]
        public async Task<IActionResult> AddRegion([FromBody]string Name)
        {
            return await base.Add(new Region { Name = Name });
        }
        [HttpPut]
        public async Task<IActionResult> UpdateRegion([FromBody]Region obj)
        {
            if (obj == null)
                BadRequest();
            if (!entity.Any(x => x.Id_region == obj.Id_region))
                return NotFound();
            return await base.Update(obj);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveRegion([FromBody]int id)
        {
            return await base.Remove(entity.FirstOrDefault(x => x.Id_region == id));
        }
        [HttpGet]
        public IEnumerable<Region> GetRegion()
        {
            return entity.ToList();
        }
        [HttpGet]
        public IActionResult GetRegionById(int id)
        {
            Region Region = entity.FirstOrDefault(x => x.Id_region == id);
            if (Region == null)
                return NotFound();
            return new ObjectResult(Region);
        }
    }
}