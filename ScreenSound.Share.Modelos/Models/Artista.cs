using System.Net.Http.Headers;

namespace ScreenSound.Models;

public class Artista : IAvaliavel
{

    public int Id { get; set; }

    public string Nome { get; set; }

    public string? Bio { get; set; }

    public string FotoPerfil { get; set; }

    public virtual ICollection<Musica> Musicas { get; set; } = new List<Musica>();

    private List<Album> albuns = new();
    private List<Avaliacao> notas = new();
    private string key;

    public virtual IReadOnlyList<Album> Albuns => albuns;

    public Artista() { } // EF precisa disso

    public Artista(string nome, string bio)
    {
        Nome = nome;
        Bio = bio;
    }

    public Artista(string key)
    {
        this.key = key;
    }

    public void AdicionarAlbum(Album album)
    {
        albuns.Add(album);
    }

    public void AdicionarNota(Avaliacao nota)
    {
        notas.Add(nota);
    }
    public double Media =>
      notas.Count == 0 ? 0 : notas.Average(n => n.Nota);
}
