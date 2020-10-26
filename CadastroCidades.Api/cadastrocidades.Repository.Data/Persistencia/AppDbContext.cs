using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using cadastrocidades.Domain.Models;

namespace cadastrocidades.Repository.Data.Persistencia
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<CidadeFroteira> CidadesFroteiras { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Cidade
            builder.Entity<Cidade>().HasKey(p => p.Id);
            builder.Entity<Cidade>().Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Entity<Cidade>().Property(p => p.NomeCidade).IsRequired().HasMaxLength(100);
            builder.Entity<Cidade>().Property(p => p.NumeroHabitantes).IsRequired();
            builder.Entity<Cidade>().HasMany(p => p.CidadesFronteira).
                WithOne(p => p.Cidade).HasForeignKey(p => p.CidadeId);


            //CidadeDeFronteira
            builder.Entity<CidadeFroteira>().HasKey(p => p.Id);
            builder.Entity<CidadeFroteira>().Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Entity<CidadeFroteira>().Property(p => p.NomeCidadeFronteira).IsRequired().HasMaxLength(100);


            //usuarios
            builder.Entity<Usuario>().HasKey(p => p.Id);
            builder.Entity<Usuario>().Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Entity<Usuario>().Property(p => p.UsuarioNome).IsRequired().HasMaxLength(30);
            builder.Entity<Usuario>().Property(p => p.Senha).IsRequired().HasMaxLength(6);
            builder.Entity<Usuario>().HasData(
                new Usuario {Id= 1,UsuarioNome = "admin", Senha = "123456"}
            );



        }
    }
}
