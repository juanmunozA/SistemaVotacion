using System.ComponentModel.DataAnnotations;

namespace SistemaDeVotaciones.Clases
{
    public class Voto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe asignarse un votante.")]
        public int VotanteId { get; set; }

        public Votante? Votante { get; set; }

        [Required(ErrorMessage = "Debe asignarse un candidato.")]
        public int CandidatoId { get; set; }

        public Candidato? Candidato { get; set; }

        public void Validar()
        {
            if (Votante == null)
                throw new Exception("Debe asociar un votante.");

            if (Votante.HaVotado)
                throw new Exception("Este votante ya ha votado.");

            if (Candidato == null)
                throw new Exception("Debe asociar un candidato.");
        }
    }
}
