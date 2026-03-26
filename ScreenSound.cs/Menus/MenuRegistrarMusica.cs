using SS.Banco;
using ScreenSound.Models;
using TrabalhoC.Menus;

internal class MenuRegistrarMusica : Menu
{
    private readonly Dictionary<string, Artista> artistasRegistradas;
    

    public MenuRegistrarMusica(Dictionary<string, Artista> artistasRegistradas)
    {
        this.artistasRegistradas = artistasRegistradas;
    }


    public override void Executar()
    {
        ExibirTitulos("Registro de músicas");

        Console.WriteLine("Caso queira registrar uma musica para uma Artista ou artista digite 1");
        int opcao = int.Parse(Console.ReadLine()!);

        Console.Write("Digite o nome da Banda ou artista da musica anterior: ");
        string nome = Console.ReadLine()!;

        Console.Write("Digite o nome da música: ");
        string nomeMusica = Console.ReadLine()!;
        Console.WriteLine("Agora digite o ano de lançamento da música");
        string AnoDeLancamento = Console.ReadLine()!;

        Musica novaMusica = new Musica(nomeMusica);

        switch (opcao)
        {
            case 1:
                RegistrarParaArtista(nome, novaMusica, AnoDeLancamento);
                break;
            default:
                Console.WriteLine("Opção inválida.");
                break;
        }

        Console.ReadKey();
        Console.Clear();
    }

    private void RegistrarParaArtista(string nomeArtista, Musica musica, string anoDeLancamento)
    {
        if (!artistasRegistradas.ContainsKey(nomeArtista))
        {
            Console.WriteLine("Artista não encontrada.");
            return;
        }

        Artista Artista = artistasRegistradas[nomeArtista];

        Console.Write("Digite o nome do álbum: ");
        string nomeAlbum = Console.ReadLine()!;

        Album? album = Artista.Albuns
            .FirstOrDefault(a => a.Nome.Equals(nomeAlbum));

        if (album is null)
        {
            Console.WriteLine("Álbum não encontrado.");
            return;
        }

        album.AdicionarMusica(musica);

        Console.WriteLine(
            $"Música '{musica.Nome}' adicionada ao álbum '{nomeAlbum}'."
        );
    }

}
