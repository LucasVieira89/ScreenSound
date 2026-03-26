using SS.Banco;
using ScreenSound.Models;
using TrabalhoC.Menus;

internal class MenuMostrarArtistas : Menu
{
    private readonly DAL<Artista> bandaDAL;

    public MenuMostrarArtistas(DAL<Artista> bandaDAL)
    {
        this.bandaDAL = bandaDAL;
    }

    public override void Executar()
    {
        Console.Clear();
        ExibirTitulos("Exibindo todas os Artistas");

        foreach (var Artista in bandaDAL.Listar())
        {
            Console.WriteLine($"Artista: {Artista.Nome}");
        }

        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}
