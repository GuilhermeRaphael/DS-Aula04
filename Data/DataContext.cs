using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RpgApi.Models;
using RpgApi.Models.Enuns;

namespace RpgApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>options) : base(options) 
        {
        }
        public DbSet<Personagem> TB_PERSONAGENS { get; set; }
        public DbSet<Arma> TB_ARMAS { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Personagem>().ToTable("TB_PERSONAGENS"); //Nome da tabela no banco de dados

            modelBuilder.Entity<Personagem>().HasData
            (
                //Colar os personagens aqui
            new Personagem() { Id = 1, Nome = "Frodo", PontosVida=100, Forca=17, Defesa=23, Inteligencia=33, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 2, Nome = "Sam", PontosVida=100, Forca=15, Defesa=25, Inteligencia=30, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 3, Nome = "Galadriel", PontosVida=100, Forca=18, Defesa=21, Inteligencia=35, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 4, Nome = "Gandalf", PontosVida=100, Forca=18, Defesa=18, Inteligencia=37, Classe=ClasseEnum.Mago },
            new Personagem() { Id = 5, Nome = "Hobbit", PontosVida=100, Forca=20, Defesa=17, Inteligencia=31, Classe=ClasseEnum.Cavaleiro },
            new Personagem() { Id = 6, Nome = "Celeborn", PontosVida=100, Forca=21, Defesa=13, Inteligencia=34, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 7, Nome = "Radagast", PontosVida=100, Forca=25, Defesa=11, Inteligencia=35, Classe=ClasseEnum.Mago }
            );

            modelBuilder.Entity<Arma>().ToTable("TB_ARMAS");

            modelBuilder.Entity<Arma>().HasData
            (
            new Arma() { Id = 1, Nome = "Espada", Dano = 5},
            new Arma() { Id = 2, Nome = "Machado", Dano = 7},
            new Arma() { Id = 3, Nome = "Cajado", Dano = 5},
            new Arma() { Id = 4, Nome = "Varinha", Dano =7},
            new Arma() { Id = 5, Nome = "Escudo",  Dano = 3},
            new Arma() { Id = 6, Nome = "Besta", Dano =8},
            new Arma() { Id = 7, Nome = "Lança", Dano = 7 }
            );

            // Area para futuros Inserts no banco de dados, so existe um ModelCreating
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveColumnType("varchar").HaveMaxLength(200);
            
        }
    }
}