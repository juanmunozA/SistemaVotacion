using System.ComponentModel.DataAnnotations;

namespace SistemaDeVotaciones.Clases
{
    public class Candidato
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El partido es obligatorio.")]
        public string Partido { get; set; } = string.Empty;

        public int CantidadVotos { get; set; } = 0;

        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
                throw new Exception("El nombre no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(Partido))
                throw new Exception("El partido no puede estar vacío.");
        }

        public void SumarVoto()
        {
            CantidadVotos++;
        }
    }
}
