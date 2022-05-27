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
    public class BrigadaController : ControllerBase
    {
        ApplicationContext db;
        public BrigadaController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brigada>>> Get()
        {
            return await db.Brigadas.ToListAsync();
        }

        // GET api/Friends/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Brigada>> Get(int id)
        {
            Brigada Brigada = await db.Brigadas.FirstOrDefaultAsync(x => x.id_brigada == id);
            if (Brigada == null)
                return NotFound();
            return new ObjectResult(Brigada);
        }

        // POST api/Friends
        [HttpPost]
        public async Task<ActionResult<Brigada>> Post(Brigada Brigada)
        {
            if (Brigada == null)
            {
                return BadRequest();
            }

            db.Brigadas.Add(Brigada);
            await db.SaveChangesAsync();
            return Ok(Brigada);
        }

        // PUT api/Friends/
        [HttpPut]
        public async Task<ActionResult<Brigada>> Put(Brigada Brigada)
        {
            if (Brigada == null)
            {
                return BadRequest();
            }
            if (!db.Brigadas.Any(x => x.id_brigada == Brigada.id_brigada))
            {
                return NotFound();
            }

            db.Update(Brigada);
            await db.SaveChangesAsync();
            return Ok(Brigada);
        }

        // DELETE api/Friends/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Brigada>> Delete(int id)
        {
            Brigada Brigada = db.Brigadas.FirstOrDefault(x => x.id_brigada == id);
            if (Brigada == null)
            {
                return NotFound();
            }
            db.Brigadas.Remove(Brigada);
            await db.SaveChangesAsync();
            return Ok(Brigada);
        }
    }
}
