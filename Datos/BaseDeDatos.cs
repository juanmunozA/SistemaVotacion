using Microsoft.EntityFrameworkCore;
using SistemaDeVotaciones.Clases;
using SistemaDeVotaciones.Controllers;

namespace SistemaDeVotaciones.Datos;

public class BaseDeDatos : DbContext
{
    public BaseDeDatos(DbContextOptions<BaseDeDatos> opciones)
        : base(opciones)
    {
    }

    public DbSet<Votante> Votantes { get; set; }
    public DbSet<Candidato> Candidatos { get; set; }
    public DbSet<Voto> Votos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Voto>()
            .HasIndex(v => v.VotanteId)
            .IsUnique(); // Un Votante solo puede votar una vez
    }
}
