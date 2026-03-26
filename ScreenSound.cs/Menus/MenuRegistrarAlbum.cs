
using SS.Banco;
using ScreenSound.Models;

namespace TrabalhoC.Menus;

internal class MenuRegistrarAlbum : Menu
{
    private readonly Dictionary<string, Artista>? bandasRegistradas;
    private readonly DAL<Musica>? MusicaDal;
    private readonly object? nomeDaBanda;
    private readonly Album album;

    public override void Executar()
    {
        ExibirTitulos("Registro de Álbum");

        Console.WriteLine("Digite o nome do Artista que esse álbum pertence:");
        string artistaAlbum = Console.ReadLine()!;

        if (bandasRegistradas.ContainsKey(artistaAlbum))
        {
            Artista artista = bandasRegistradas[artistaAlbum];

            artista.AdicionarAlbum(album);

            Console.WriteLine("Álbum adicionado com sucesso!");
        }
        else
        {
            Console.WriteLine("Artista não encontrado.");
            Console.Write("Digite o nome do álbum: ");
            string nomeDoAlbum = Console.ReadLine()!;
            Album album = new Album(nomeDoAlbum);



            Console.WriteLine($"Álbum '{nomeDoAlbum}' adicionado!");
            Thread.Sleep(2000);
        }

    }
}
