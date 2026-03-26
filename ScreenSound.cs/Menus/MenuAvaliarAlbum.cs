
using SS.Banco;
using Microsoft.EntityFrameworkCore.Update;
using ScreenSound.Models;
using System.Diagnostics.Eventing.Reader;

namespace TrabalhoC.Menus;

internal class MenuAvaliarAlbum : Menu
{
    private readonly Dictionary<string, Artista>? bandasRegistradas;
    private readonly DAL<Musica>? MusicaDal;

    public override void Executar()
    {
        ExibirTitulos("Avaliação de Album");

        Console.WriteLine("Digite o Nome do Artista que esse album pertence:");
        var nomeArtista = Console.ReadLine()!;

        if (!bandasRegistradas.ContainsKey(nomeArtista))
        {
            Console.WriteLine("Artista não encontrado.");
            return;
        }

        Artista artista = bandasRegistradas[nomeArtista];

        Console.Write("Digite o nome do Album que deseja registrar: ");
        string tituloAlbum = Console.ReadLine()!;

        if (artista.Albuns.Any(a => a.Nome.Equals(tituloAlbum)))
        {
            Album album = artista.Albuns.First(a => a.Nome.Equals(tituloAlbum));

            Console.Write($"Qual nota {tituloAlbum} merece? ");
            int valorNota = int.Parse(Console.ReadLine()!);

            Avaliacao nota = new Avaliacao(valorNota);
            album.AdicionarNota(nota);

            Console.WriteLine($"\nA nota {nota.Nota} foi registrada com sucesso para {tituloAlbum}!");
            Thread.Sleep(2000);
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"\nO álbum {tituloAlbum} não foi encontrado.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}