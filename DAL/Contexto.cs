using GestionJugadores.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionJugadores.DAL;

public class Contexto : DbContext
{
    public Contexto (DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<Jugadores> Jugadores { get; set; }
}
