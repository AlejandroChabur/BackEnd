﻿using BackEnd.Model;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Context
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions options) :base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

        public DbSet<IdentificationType> IdentificationTypes { get; set; }
        public DbSet<People> People { get; set; }
        public DbSet<Authors> Authors { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Edition> Editions { get; set; }
        public DbSet<Topics> Topics { get; set; }
        public DbSet<Editorials> Editorials { get; set; }
        public DbSet<Loans> Loans { get; set; }
        public DbSet<Reports> Reports { get; set; }
        public DbSet<Formats> Formats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de la entidad User
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            // Configuración de la relación entre User y People
            modelBuilder.Entity<User>()
                .HasOne<People>()
                .WithMany()
                .HasForeignKey(u => u.IdPersona); // Relaciona IdPersona de User con Id de People

            // Configuración de la entidad People
            modelBuilder.Entity<People>()
                .ToTable("People"); // Especifica la tabla para People

            // Configuración de la herencia entre People y Authors
            modelBuilder.Entity<Authors>()
                .ToTable("Authors") // Especifica la tabla para Authors
                .HasBaseType<People>(); // Establece que Authors hereda de People

            // Configuración adicional para Authors
            modelBuilder.Entity<Authors>()
                .Property(a => a.Country)
                .IsRequired(); // Especifica que el campo Country es requerido
        }

       
    }
}
