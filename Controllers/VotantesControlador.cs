using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeVotaciones.Clases;
using SistemaDeVotaciones.Datos;

namespace SistemaDeVotaciones.Controllers
{
    [ApiController]
    [Route("api/votantes")]
    public class VotantesControlador : ControllerBase
    {
        private readonly BaseDeDatos _contexto;

        public VotantesControlador(BaseDeDatos contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Votante>>> ObtenerTodos()
        {
            return await _contexto.Votantes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Votante>> ObtenerPorId(int id)
        {
            var votante = await _contexto.Votantes.FindAsync(id);
            return votante == null ? NotFound() : votante;
        }

        [HttpPost]
        public async Task<ActionResult<Votante>> Crear(Votante votante)
        {
            try
            {
                votante.Validar();
                _contexto.Votantes.Add(votante);
                await _contexto.SaveChangesAsync();
                return CreatedAtAction(nameof(ObtenerPorId), new { id = votante.Id }, votante);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var votante = await _contexto.Votantes.FindAsync(id);
            if (votante == null) return NotFound();

            _contexto.Votantes.Remove(votante);
            await _contexto.SaveChangesAsync();
            return NoContent();
        }
    }
}
