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
    public class CmenaController : ControllerBase
    {
        ApplicationContext db;
        public CmenaController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cmena>>> Get()
        {
            return await db.Cmenas.ToListAsync();
        }

        // GET api/Friends/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cmena>> Get(int id)
        {
            Cmena Cmena = await db.Cmenas.FirstOrDefaultAsync(x => x.id_cotry == id);
            if (Cmena == null)
                return NotFound();
            return new ObjectResult(Cmena);
        }

        // POST api/Friends
        [HttpPost]
        public async Task<ActionResult<Cmena>> Post(Cmena Cmena)
        {
            if (Cmena == null)
            {
                return BadRequest();
            }

            db.Cmenas.Add(Cmena);
            await db.SaveChangesAsync();
            return Ok(Cmena);
        }

        // PUT api/Friends/
        [HttpPut]
        public async Task<ActionResult<Cmena>> Put(Cmena Cmena)
        {
            if (Cmena == null)
            {
                return BadRequest();
            }
            if (!db.Cmenas.Any(x => x.id_cotry == Cmena.id_cotry))
            {
                return NotFound();
            }

            db.Update(Cmena);
            await db.SaveChangesAsync();
            return Ok(Cmena);
        }

        // DELETE api/Friends/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cmena>> Delete(int id)
        {
            Cmena Cmena = db.Cmenas.FirstOrDefault(x => x.id_cotry == id);
            if (Cmena == null)
            {
                return NotFound();
            }
            db.Cmenas.Remove(Cmena);
            await db.SaveChangesAsync();
            return Ok(Cmena);
        }

    }
}
