using System.ComponentModel.DataAnnotations;

namespace GestionJugadores.Models
{
    public class Jugadores
    {
        [Key]

        public int JugadorId {  get; set; }

        [Required(ErrorMessage = "Campo requerido")]

        public String Nombres { get; set; } = null!;

        [Required(ErrorMessage = "Campo requerido")]

        public int Partidas { get; set; }
    }
}
