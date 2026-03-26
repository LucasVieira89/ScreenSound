
namespace ScreenSound.Models;

public class Album : IAvaliavel
{
    public int Id { get; set; }

    private List<Avaliacao> notas = new();
    private List<Musica> musicas = new();

    public string Nome { get;set; }

    public Album() { } // EF precisa disso

    public Album(string nome)
    {
        Nome = nome;
    }

    public virtual IReadOnlyList<Musica> Musicas => musicas;

    public void AdicionarMusica(Musica musica)
    {
        musicas.Add(musica);
    }

    public void AdicionarNota(Avaliacao nota)
    {
        notas.Add(nota);
    }

    public double Media =>
        notas.Count == 0 ? 0 : notas.Average(n => n.Nota);
}
