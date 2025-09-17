using GestionJugadores.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionJugadores.DAL;

public class Contexto : DbContext
{
    public DbSet<Jugadores> Jugadores { get; set; }
    public DbSet<Partidas> Partidas { get; set; }
    public DbSet<Movimientos> Movimientos { get; set; } 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Partidas>()
            .HasOne(p => p.Jugador1)
            .WithMany()
            .HasForeignKey(p => p.Jugador1Id)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Partidas>()
            .HasOne(p => p.Jugador2)
            .WithMany()
            .HasForeignKey(p => p.Jugador2Id)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Partidas>()
            .HasOne(p => p.Ganador)
            .WithMany()
            .HasForeignKey(p => p.GanadorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Partidas>()
            .HasOne(p => p.TurnoJugador)
            .WithMany()  
            .HasForeignKey(p => p.TurnoJugadorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Movimientos>()
        .HasOne(m => m.Partida) 
        .WithMany(p => p.Movimiento)          
        .HasForeignKey(m => m.PartidaId)
        .OnDelete(DeleteBehavior.Cascade);     

        modelBuilder.Entity<Movimientos>()
            .HasOne(m => m.Jugador)               
            .WithMany(j => j.Movimiento)   
            .HasForeignKey(m => m.JugadorId)
            .OnDelete(DeleteBehavior.Restrict);


        base.OnModelCreating(modelBuilder);
    }

    public Contexto (DbContextOptions<Contexto> options) : base(options) { }
}