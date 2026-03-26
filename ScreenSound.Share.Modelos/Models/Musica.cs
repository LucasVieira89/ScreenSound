using ScreenSound.Models;
using System.Reflection.Metadata.Ecma335;

public class Musica
{
    public int Id { get; set; }

    public string Nome { get;set; } 
    public int Duracao { get; set; }
    public bool Disponivel { get; set; }

    public int? AnoDeLancamento { get; set; }

    public virtual ICollection <Genero> Generos { get; set; }
    virtual public Artista? Artista { get; set; }
    public int ArtistaId { get; set; }

    public Musica() { }

    public Musica(string nome)
    {
        Nome = nome;
    }

    public void ExibirFicha()
    {
        Console.WriteLine($"Música: {Nome}");
        Console.WriteLine($"Duração: {Duracao}");
        Console.WriteLine($"Disponível: {Disponivel}");
        Console.WriteLine($"Ano de Lançamento da Musica: {AnoDeLancamento}");
    }
}






