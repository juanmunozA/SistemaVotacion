using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeVotaciones.Clases;
using SistemaDeVotaciones.Datos;

namespace SistemaDeVotaciones.Controllers
{
    [ApiController]
    [Route("api/votos")]
    public class VotosControlador : ControllerBase
    {
        private readonly BaseDeDatos _contexto;

        public VotosControlador(BaseDeDatos contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Voto>>> ObtenerTodos()
        {
            return await _contexto.Votos
                .Include(v => v.Votante)
                .Include(v => v.Candidato)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Voto>> Crear(Voto voto)
        {
            try
            {
                var votante = await _contexto.Votantes.FindAsync(voto.VotanteId);
                var candidato = await _contexto.Candidatos.FindAsync(voto.CandidatoId);

                voto.Votante = votante;
                voto.Candidato = candidato;

                voto.Validar();

                // Marcar que ya votó y aumentar votos al candidato
                votante!.HaVotado = true;
                candidato!.SumarVoto();

                _contexto.Votos.Add(voto);
                await _contexto.SaveChangesAsync();

                return CreatedAtAction(nameof(ObtenerTodos), new { id = voto.Id }, voto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
