using Microsoft.EntityFrameworkCore;
using ScreenSound.Models;

namespace SS.Banco;

public class ScreenSoundContext : DbContext
{

    public ScreenSoundContext(DbContextOptions<ScreenSoundContext> options)
       : base(options)
    {
    }
    public DbSet<Artista> Artistas { get; set; }
    public DbSet<Musica> Musicas { get; set; }
    public DbSet<Genero> Generos { get; set; }

    //private string connectionString =
        //"Server=localhost;Database=ScreenSoundDB;Trusted_Connection=True;TrustServerCertificate=True;";

   // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
       // optionsBuilder.UseSqlServer(connectionString);
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
  
        modelBuilder.Entity<Musica>().ToTable("Musica");
        modelBuilder.Entity<Artista>().ToTable("Artistas");
        modelBuilder.Entity<Album>().ToTable("Album");
        modelBuilder.Entity<Artista>().Ignore(a => a.Albuns);
        modelBuilder.Entity<Artista>().Ignore("notas");

        modelBuilder.Entity<Musica>()
       .HasMany(m => m.Generos)
       .WithMany(g => g.Musicas);


        modelBuilder.Entity<Artista>().HasData(
        new Artista
        {
            Id = 1,
            Nome = "Djavan",
            Bio = "Cantor e compositor brasileiro conhecido pela mistura de MPB, jazz e funk.",
            FotoPerfil = "https://upload.wikimedia.org/wikipedia/commons/5/5a/Djavan_2012.jpg"
        },
        new Artista
        {
            Id = 2,
            Nome = "Foo Fighters",
            Bio = "Banda de rock alternativo formada por Dave Grohl após o Nirvana.",
            FotoPerfil = "https://upload.wikimedia.org/wikipedia/commons/9/9f/Foo_Fighters_2017.jpg"
        },
        new Artista
        {
            Id = 3,
            Nome = "Frank Sinatra",
            Bio = "Cantor e ator americano, um dos maiores nomes da música do século XX.",
            FotoPerfil = "https://upload.wikimedia.org/wikipedia/commons/a/af/Frank_Sinatra_1960.jpg"
        },
        new Artista
        {
            Id = 4,
            Nome = "Ray Charles",
            Bio = "Pioneiro da soul music, combinando gospel, blues e jazz.",
            FotoPerfil = "https://upload.wikimedia.org/wikipedia/commons/8/87/Ray_Charles_1968.jpg"
        },
        new Artista
        {
            Id = 5,
            Nome = "B.B. King",
            Bio = "Lendário guitarrista e cantor de blues, conhecido como 'Rei do Blues'.",
            FotoPerfil = "https://upload.wikimedia.org/wikipedia/commons/9/9c/BB_King_2009.jpg"
        }
    );

    }
}