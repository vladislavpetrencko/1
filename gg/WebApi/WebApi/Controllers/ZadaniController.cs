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
    public class ZadaniController : ControllerBase
    {
        ApplicationContext db;
        public ZadaniController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zadani>>> Get()
        {
            return await db.Zadanis.ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Zadani>> Get(int id)
        {
            Zadani Zadani = await db.Zadanis.FirstOrDefaultAsync(x => x.id_zadani == id);
            if (Zadani == null)
                return NotFound();
            return new ObjectResult(Zadani);
        }

        
        [HttpPost]
        public async Task<ActionResult<Zadani>> Post(Zadani Zadani)
        {
            if (Zadani == null)
            {
                return BadRequest();
            }

            db.Zadanis.Add(Zadani);
            await db.SaveChangesAsync();
            return Ok(Zadani);
        }

        
        [HttpPut]
        public async Task<ActionResult<Zadani>> Put(Zadani Zadani)
        {
            if (Zadani == null)
            {
                return BadRequest();
            }
            if (!db.Zadanis.Any(x => x.id_zadani == Zadani.id_zadani))
            {
                return NotFound();
            }

            db.Update(Zadani);
            await db.SaveChangesAsync();
            return Ok(Zadani);
        }

        // DELETE api/Friends/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Zadani>> Delete(int id)
        {
            Zadani Zadani = db.Zadanis.FirstOrDefault(x => x.id_zadani == id);
            if (Zadani == null)
            {
                return NotFound();
            }
            db.Zadanis.Remove(Zadani);
            await db.SaveChangesAsync();
            return Ok(Zadani);
        }
    }
}
