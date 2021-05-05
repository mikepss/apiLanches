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
        public DbSet<Ingrediente> ingredientes { get; set; }
        public DbSet<Adicional> adicionais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //LANCHES
            modelBuilder.Entity<Lanche>()
                .Property(p => p.nome)
                    .HasMaxLength(80);

            modelBuilder.Entity<Lanche>()
                .HasData(
                new Lanche { id = 1, nome = "X-Bacon" },
                new Lanche { id = 2, nome = "X-Burger" },
                new Lanche { id = 3, nome = "X-Egg" },
                new Lanche { id = 4, nome = "X-Egg Bacon" });

            //INGREDIENTES
            modelBuilder.Entity<Ingrediente>()
                .Property(p => p.nome)
                    .HasMaxLength(80);
            modelBuilder.Entity<Ingrediente>()
                .Property(p => p.preco)
                    .HasPrecision(10,2);

            modelBuilder.Entity<Ingrediente>()
                .HasData(
                new Ingrediente { id = 1, nome = "Salada" },
                new Ingrediente { id = 2, nome = "Bacon" },
                new Ingrediente { id = 3, nome = "Hambúrger de Carne" },
                new Ingrediente { id = 4, nome = "Ovo" },
                new Ingrediente { id = 5, nome = "Queijo" });

            //ADICIONAIS
            modelBuilder.Entity<Adicional>()
                .HasData(
                new Adicional { id = 1, idIngrediente=2, idLanche=1 },
                new Adicional { id = 2, idIngrediente = 3, idLanche = 1 },
                new Adicional { id = 3, idIngrediente = 5, idLanche = 1 },

                new Adicional { id = 4, idIngrediente = 3, idLanche = 2 },
                new Adicional { id = 5, idIngrediente = 5, idLanche = 2 },

                new Adicional { id = 6, idIngrediente = 3, idLanche = 3 },
                new Adicional { id = 7, idIngrediente = 4, idLanche = 3 },
                new Adicional { id = 8, idIngrediente = 5, idLanche = 3 },

                new Adicional { id = 9, idIngrediente = 2, idLanche = 4 },
                new Adicional { id = 10, idIngrediente = 3, idLanche = 4 },
                new Adicional { id = 11, idIngrediente = 4, idLanche = 4 },
                new Adicional { id = 12, idIngrediente = 5, idLanche = 4 });
        }
    }
}
