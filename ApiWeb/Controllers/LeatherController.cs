using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiWeb.Controllers
{
    [Route("[controller]/[action]")]
    public class LeatherController : BaseApiController<Leather>
    {
        public LeatherController(CreateContextModel contextModel) : base(contextModel) { }
        /// <summary>
        /// Добавление данных
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddLether([FromBody]string Name)
        {
            return await base.Add(new Leather { Name = Name });
        }
        [HttpPut]
        public async Task<IActionResult> UpdateLether([FromBody]Leather obj)
        {
            if (obj == null)
                BadRequest();
            if (!entity.Any(x => x.Id_leather == obj.Id_leather))
                return NotFound();
            return await base.Update(obj);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveLether([FromBody]int id)
        {
            return await base.Remove(entity.FirstOrDefault(x => x.Id_leather == id));
        }
        [HttpGet]
        public IEnumerable<Leather> GetLeather()
        {
            return entity.ToList();
        }
        [HttpGet]
        public IActionResult GetLeatherById(int id)
        {
            Leather leather = entity.FirstOrDefault(x => x.Id_leather == id);
            if (leather == null)
                return NotFound();
            return new ObjectResult(leather);
        }
    }
}