namespace SS.Menus;

using SS.Banco;
using ScreenSound.Models;
using TrabalhoC.Menus;

internal class MenuMostrarMusicas : Menu
{
    private readonly DAL<Musica> musicaDAL;

    public MenuMostrarMusicas(DAL<Musica> musicaDAL)
    {
        this.musicaDAL = musicaDAL;
    }

    public override void Executar()
    {
        Console.Clear();
        ExibirTitulos("Exibindo todas as músicas");

        var musicas = musicaDAL.Listar();

        if (!musicas.Any())
        {
            Console.WriteLine("Nenhuma música cadastrada.");
            Console.ReadKey();
            return;
        }

        foreach (var musica in musicas)
        {
            Console.WriteLine($"- {musica.Nome}");
        }

        Console.Write("\nDigite o nome da música para ver a ficha: ");
        string nomeMusica = Console.ReadLine()!;

        var musicaSelecionada =
            musicas.FirstOrDefault(m => m.Nome.Equals(nomeMusica));

        if (musicaSelecionada is null)
        {
            Console.WriteLine("Música não encontrada.");
        }
        else
        {
            Console.Clear();
            musicaSelecionada.ExibirFicha();
        }

        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}

    
    

