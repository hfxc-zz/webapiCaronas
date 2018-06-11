using AvaCarona.API.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvaCarona.API.Repositories
{
    public class CaronaAppContext : DbContext
    {
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Carona> Caronas { get; set; }

        public CaronaAppContext()
        {
            Database.EnsureCreated();
        }

        public CaronaAppContext(DbContextOptions<CaronaAppContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaronaColaborador>()
                .HasKey(s => new { s.ColaboradorId, s.CaronaId });

            modelBuilder.Entity<CaronaColaborador>()
                .HasOne(cc => cc.Carona)
                .WithMany(ca => ca.Caroneiros)
                .HasForeignKey(cc => cc.CaronaId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=CaronaDB;Trusted_Connection=True;");
            }
        }
    }
}
