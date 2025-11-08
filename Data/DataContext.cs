using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RpgApi.Models;
using Microsoft.EntityFrameworkCore;
using RpgApi.Models.Enuns;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RpgApi.Utils;

namespace RpgApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Personagem> TB_PERSONAGENS { get; set; }

        public DbSet<Armas> TB_ARMAS { get; set; }
        public DbSet<Usuario> TB_USUARIOS { get; set; }

        public DbSet<Habilidade> TB_HABILIDADES { get; set; }

        public DbSet<PersonagemHabilidade> TB_PERSONAGNS_HABILIDADES { get; set; }
        public DbSet<Disputa> TB_DISPUTAS { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Habilidade>().ToTable("TB_HABILIDADES");
            modelBuilder.Entity<PersonagemHabilidade>().ToTable("TB_PERSONAGNS_HABILIDADES");
            modelBuilder.Entity<Disputa>().ToTable("TB_DISPUTAS");
            
            modelBuilder.Entity<Personagem>()
                .HasOne(e =>  e.Arma)
                .WithOne(e => e.Personagem)
                .HasForeignKey<Armas>(e => e.PersonagemId)
                .IsRequired();

            modelBuilder.Entity<Personagem>().HasData
            (
            new Personagem() { Id = 1, Nome = "Frodo", PontosVida=100, Forca=17, Defesa=23, Inteligencia=33, Classe=ClasseEnum.Cavaleiro, UsuarioId = 1 },
            new Personagem() { Id = 2, Nome = "Sam", PontosVida=100, Forca=15, Defesa=25, Inteligencia=30, Classe=ClasseEnum.Cavaleiro, UsuarioId = 1 },
            new Personagem() { Id = 3, Nome = "Galadriel", PontosVida=100, Forca=18, Defesa=21, Inteligencia=35, Classe=ClasseEnum.Clerigo, UsuarioId = 1 },
            new Personagem() { Id = 4, Nome = "Gandalf", PontosVida=100, Forca=18, Defesa=18, Inteligencia=37, Classe=ClasseEnum.Mago, UsuarioId = 1 },
            new Personagem() { Id = 5, Nome = "Hobbit", PontosVida=100, Forca=20, Defesa=17, Inteligencia=31, Classe=ClasseEnum.Cavaleiro, UsuarioId = 1 },
            new Personagem() { Id = 6, Nome = "Celeborn", PontosVida=100, Forca=21, Defesa=13, Inteligencia=34, Classe=ClasseEnum.Clerigo, UsuarioId = 1 },
            new Personagem() { Id = 7, Nome = "Radagast", PontosVida=100, Forca=25, Defesa=11, Inteligencia=35, Classe=ClasseEnum.Mago, UsuarioId = 1 }
            );
            modelBuilder.Entity<Armas>().ToTable("TB_ARMAS");

            

            modelBuilder.Entity<Armas>().HasData
            (
            new Armas() { Id = 1, Nome = "Rabaddon", Dano = 10, PersonagemId = 1},
            new Armas() { Id = 2, Nome = "Rei destruido", Dano = 10, PersonagemId = 2},
            new Armas() { Id = 3, Nome = "Cutelo Negro", Dano = 10, PersonagemId = 3},
            new Armas() { Id = 4, Nome = "Mascara de Liandry", Dano = 10, PersonagemId = 4},
            new Armas() { Id = 5, Nome = "LeBron James", Dano = 10, PersonagemId = 5},
            new Armas() { Id = 6, Nome = "Faquinha de cortar pão", Dano = 10, PersonagemId = 6},
            new Armas() { Id = 7, Nome = "Chinelo de mãe", Dano = 10, PersonagemId = 7}
            );

            modelBuilder.Entity<PersonagemHabilidade>()
                .HasKey(ph => new {ph.PersonagemId, ph.HabilidadeId });

            modelBuilder.Entity<Habilidade>().HasData
            (
                new Habilidade(){Id = 1, Nome="Lentidão", Dano = 10},
                new Habilidade(){Id = 2, Nome="Ceguera", Dano = 12},
                new Habilidade(){Id = 3, Nome="Caimbra", Dano = 15},
                new Habilidade(){Id = 4, Nome="Estocada", Dano = 30},
                new Habilidade(){Id = 5, Nome="Dose de oraçao", Dano = 20},
                new Habilidade(){Id = 6, Nome="Arremesso de orbe", Dano = 40}
                //new Habilidade(){Id = 7, Nome="Torçao Testicular", Dano = 90},
            );

            modelBuilder.Entity<PersonagemHabilidade>().HasData
            (
                new PersonagemHabilidade() { PersonagemId = 1, HabilidadeId = 1},
                new PersonagemHabilidade() { PersonagemId = 1, HabilidadeId = 2},
                new PersonagemHabilidade() { PersonagemId = 2, HabilidadeId = 2},
                new PersonagemHabilidade() { PersonagemId = 3, HabilidadeId = 2},
                new PersonagemHabilidade() { PersonagemId = 3, HabilidadeId = 3},
                new PersonagemHabilidade() { PersonagemId = 4, HabilidadeId = 3},
                new PersonagemHabilidade() { PersonagemId = 5, HabilidadeId = 1},
                new PersonagemHabilidade() { PersonagemId = 6, HabilidadeId = 2},
                new PersonagemHabilidade() { PersonagemId = 7, HabilidadeId = 3}
            );   

            modelBuilder.Entity<Usuario>().ToTable("TB_USUARIOS");

            //Relacionamento One to Many (Um para muitos)
            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Personagens)
                .WithOne(e => e.Usuario)
                .HasForeignKey(e => e.UsuarioId)
                .IsRequired(false);



                 //Início da criação do usuário padrão.
            Usuario user = new Usuario();
            Criptografia.CriarPasswordHash("123456", out byte[] hash, out byte[] salt);
            user.Id = 1;
            user.Username = "UsuarioAdmin";
            user.PasswordString = string.Empty;
            user.PasswordHash = hash;
            user.PasswordSalt = salt;
            user.Perfil = "Admin";
            user.Email = "seuEmail@gmail.com";
            user.Latitude = -23.5200241;
            user.Longitude = -46.596498;

            modelBuilder.Entity<Usuario>().HasData(user);

            modelBuilder.Entity<Disputa>().HasKey(d => d.Id);
            modelBuilder.Entity<Disputa>().Property(d => d.DataDisputa).HasColumnName("Dt_Disputa");
            modelBuilder.Entity<Disputa>().Property(a => a.AtacanteId).HasColumnName("AtacanteId");
            modelBuilder.Entity<Disputa>().Property(o => o.OponenteId).HasColumnName("OponenteId");
            modelBuilder.Entity<Disputa>().Property(n => n.Narracao).HasColumnName("Tx_Narracao");
            
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveColumnType("varchar").HaveMaxLength(200);
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }





    }
}