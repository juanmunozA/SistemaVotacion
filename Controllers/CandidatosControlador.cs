using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeVotaciones.Clases;
using SistemaDeVotaciones.Datos;

namespace SistemaDeVotaciones.Controllers
{
    [ApiController]
    [Route("api/candidatos")]
    public class CandidatosControlador : ControllerBase
    {
        private readonly BaseDeDatos _contexto;

        public CandidatosControlador(BaseDeDatos contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Candidato>>> ObtenerTodos()
        {
            return await _contexto.Candidatos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Candidato>> ObtenerPorId(int id)
        {
            var candidato = await _contexto.Candidatos.FindAsync(id);
            return candidato == null ? NotFound() : candidato;
        }

        [HttpPost]
        public async Task<ActionResult<Candidato>> Crear(Candidato candidato)
        {
            try
            {
                candidato.Validar();
                _contexto.Candidatos.Add(candidato);
                await _contexto.SaveChangesAsync();
                return CreatedAtAction(nameof(ObtenerPorId), new { id = candidato.Id }, candidato);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var candidato = await _contexto.Candidatos.FindAsync(id);
            if (candidato == null) return NotFound();

            _contexto.Candidatos.Remove(candidato);
            await _contexto.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("conteo-votos")]
        public async Task<ActionResult<IEnumerable<object>>> ObtenerConteoVotos()
        {
            var conteo = await _contexto.Candidatos
                .Select(c => new { c.Nombre, c.Partido, c.CantidadVotos })
                .ToListAsync();

            return conteo;
        }
    }
}
