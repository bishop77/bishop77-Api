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
    public abstract class BaseApiController<T> : ControllerBase where T : class
    {
        protected readonly CreateContextModel db;
        protected DbSet<T> entity;

        public BaseApiController(CreateContextModel contextModel)
        {
            this.db = contextModel;
            this.entity = db.Set<T>();
        }

        protected async Task<IActionResult> Add(T obj)
        {
            if (ModelState.IsValid)
            {
                entity.Add(obj);
                await db.SaveChangesAsync();
                return Ok(obj);
            }
            return BadRequest();
        }
        protected async Task<IActionResult> Update(T obj)
        {
            entity.Update(obj);
            await db.SaveChangesAsync();
            return Ok(obj);
        }
        protected async Task<IActionResult> Remove(T obj)
        {
            if (obj == null)
                return NotFound();
            entity.Remove(obj);
            await db.SaveChangesAsync();
            return Ok(obj);
        }
    }
}