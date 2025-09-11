using GestionJugadores.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionJugadores.DAL;

public class Contexto : DbContext
{
    public DbSet<Jugadores> Jugadores { get; set; }
    public Contexto (DbContextOptions<Contexto> options) : base(options) { }

}
