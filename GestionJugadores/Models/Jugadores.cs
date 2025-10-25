using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionJugadores.Models;

public class Jugadores
{
    [Key]
    public int JugadorId {  get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    public string Nombres { get; set; } = null!;

    [Range(0, int.MaxValue, ErrorMessage = "Numero de victorias no valido")]
    public int Victorias { get; set; } = 0;

    [Range(0,int.MaxValue, ErrorMessage = "Numero de derrotas no valido")]
    public int Derrotas { get; set; } = 0;

    [Range(0,int.MaxValue,ErrorMessage = "Numero de empates no valido")]
    public int Empates { get; set; } = 0;

    [InverseProperty(nameof(Models.Movimientos.Jugador))]
    public virtual ICollection<Movimientos> Movimientos { get; set; } = new List<Movimientos>();    
}
