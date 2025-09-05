using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace GestionJugadores.Models
{
    public class Jugadores
    {
        [Key]
        public int JugadorId {  get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public String Nombres { get; set; } = null!;

        [Range(0, int.MaxValue, ErrorMessage = "Numero de partidas no valido")]
        public int Partidas { get; set; }
    }
}
