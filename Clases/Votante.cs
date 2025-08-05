using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SistemaDeVotaciones.Clases
{
    public class Votante
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public required string Nombre { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "Correo electrónico inválido")]
        public required string Correo { get; set; }

        public bool HaVotado { get; set; } = false;


        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
                throw new Exception("El nombre no puede estar vacío.");


        }

    }
}