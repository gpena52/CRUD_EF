using CRUD_EF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_EF.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TareaController : ControllerBase
    {
        private readonly OpenSourceContext _db;

        public TareaController(OpenSourceContext db)
        {
            _db = db;
        }

        [HttpGet("Obtener")]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _db.Tareas.ToListAsync());
        }

        [HttpGet(":id")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            Tarea tarea = await _db.Tareas.FirstOrDefaultAsync(t => t.Id == id);
            if (tarea == null) return NotFound();
            return Ok(tarea);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Tarea tarea)
        {
            await _db.Tareas.AddAsync(tarea);
            await _db.SaveChangesAsync();
            return CreatedAtAction(null, null, tarea);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(Tarea tarea)
        {
            Tarea tareaDB = await _db.Tareas.FirstOrDefaultAsync(t => t.Id == tarea.Id);

            if (tareaDB == null) return NotFound();

            tareaDB.Titulo = tarea.Titulo;
            tareaDB.Estado = tarea.Estado;

            await _db.SaveChangesAsync();

            return Ok(tarea);
        }

        [HttpDelete(":id")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            Tarea tareaDB = await _db.Tareas.FirstOrDefaultAsync(t => t.Id == id);

            if (tareaDB == null) return NotFound();

            _db.Remove(tareaDB);

            await _db.SaveChangesAsync();

            return Ok(tareaDB);
        }
    }
}
