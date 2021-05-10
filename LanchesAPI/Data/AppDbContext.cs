using LanchesAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanchesAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Lanche> Lanches { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<Adicional> Adicionais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //INGREDIENTES
            modelBuilder.Entity<Ingrediente>()
                .Property(p => p.Preco)
                    .HasPrecision(10,2);

            //ADICIONAIS
            modelBuilder.Entity<Adicional>(entity =>
            {
                entity.HasKey(e => new { e.LancheId, e.IngredienteId });
            });


        }
    }
}
