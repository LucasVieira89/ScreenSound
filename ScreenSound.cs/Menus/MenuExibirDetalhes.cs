using SS.Banco;
using Microsoft.Identity.Client;
using ScreenSound.Models;

namespace TrabalhoC.Menus;

internal class MenuExibirDetalhes : Menu
{
    private readonly Dictionary<string, Artista> ArtistasRegistradas;
    private readonly DAL<Musica> MusicaDal;

    public MenuExibirDetalhes()
   {
   }

    public MenuExibirDetalhes(Dictionary<string, Artista> artistasRegistradas, DAL<Musica> musicaDal) 
    {
        ArtistasRegistradas = artistasRegistradas;
        MusicaDal = musicaDal;
    }

    public override void Executar()
    {
        Console.Clear();
        ExibirTitulos("Exbindo Detalhes do Artista ou da Musica.");
        Console.WriteLine("Exindo Detalhes de:");
        Console.WriteLine("1- Artista/Artista");
        Console.WriteLine("2- Musica");
        Console.ReadLine();
        int opcao = int.Parse(Console.ReadLine()!);
        

        switch (opcao)
        {
            case 1:
                Console.WriteLine("Opcao 1 escolhida!");
                DetalhesDoArtista();
                break;

            case 2:
                Console.WriteLine("Opcao 2 escolhida!");
                DetalhesDaMusica();
                break;

            default:
                Console.WriteLine("Opção invalida!");
                Console.WriteLine("Digite qualquer tecla para sair!");
                Console.ReadKey();
                Console.Clear();
                break;
        }
    }

    private void DetalhesDoArtista()
    {
        ExibirTitulos("Exibir detalhes da Artista");
        Console.Write("Digite o nome da Artista que deseja conhecer melhor: ");
        string nomeDoArtista = Console.ReadLine()!;
        if (ArtistasRegistradas.ContainsKey(nomeDoArtista))
        {
            Artista Artista = ArtistasRegistradas[nomeDoArtista];
            Console.WriteLine($"\nA média da Artista {nomeDoArtista} é {Artista.Media}.");
            Console.WriteLine("\nDiscografia:");
            foreach (Album album in Artista.Albuns)
            {
                Console.WriteLine($"{album.Nome} -> {album.Media} ");
            }
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();

        }
        else
        {
            Console.WriteLine($"\nA Artista {nomeDoArtista} não foi encontrada!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();

        }
    }

    private void DetalhesDaMusica()
    {
        ExibirTitulos("Exibir detalhes da música");

        Console.Write("Digite o nome da música: ");
        string nomeDaMusica = Console.ReadLine()!;

        var musicaRecuperada = MusicaDal.RecuperarPor(m => m.Nome.Equals(nomeDaMusica));

        if (musicaRecuperada is not null)
        {
            Console.WriteLine($"\nMúsica encontrada: {musicaRecuperada.Nome}");
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"\nA música {nomeDaMusica} não foi encontrada!");
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }




}

