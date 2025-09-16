using System.ComponentModel.DataAnnotations;

namespace GestionJugadores.Models;

public class Jugadores
{
    [Key]
    public int JugadorId {  get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    public String Nombres { get; set; } = null!;

    [Range(0, int.MaxValue, ErrorMessage = "Numero de partidas no valido")]
    public int Victorias { get; set; } = 0;

    public int Derrotas { get; set; } = 0;

    public int Empates { get; set; } = 0;
}
