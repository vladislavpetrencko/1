using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpoveController : ControllerBase
    {
        ApplicationContext db;
        public OpoveController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Opove>>> Get()
        {
            return await db.Opoves.ToListAsync();
        }

        // GET api/Friends/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Opove>> Get(int id)
        {
            Opove Opove = await db.Opoves.FirstOrDefaultAsync(x => x.id_zaiv == id);
            if (Opove == null)
                return NotFound();
            return new ObjectResult(Opove);
        }

        // POST api/Friends
        [HttpPost]
        public async Task<ActionResult<Opove>> Post(Opove Opove)
        {
            if (Opove == null)
            {
                return BadRequest();
            }
            
            db.Opoves.Add(Opove);
            await db.SaveChangesAsync();
            return Ok(Opove);
        }

        // PUT api/Friends/
        [HttpPut]
        public async Task<ActionResult<Opove>> Put(Opove Opove)
        {
            if (Opove == null)
            {
                return BadRequest();
            }
            if (!db.Opoves.Any(x => x.id_zaiv == Opove.id_zaiv))
            {
                return NotFound();
            }

            db.Update(Opove);
            await db.SaveChangesAsync();
            return Ok(Opove);
        }

        // DELETE api/Friends/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Opove>> Delete(int id)
        {
            Opove Opove = db.Opoves.FirstOrDefault(x => x.id_zaiv == id);
            if (Opove == null)
            {
                return NotFound();
            }
            db.Opoves.Remove(Opove);
            await db.SaveChangesAsync();
            return Ok(Opove);
        }
    }
}
