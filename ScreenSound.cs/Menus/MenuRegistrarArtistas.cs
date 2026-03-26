using SS.Banco;
using ScreenSound.Models;
using TrabalhoC.Menus;

namespace SS.Menus;

internal class MenuRegistrarArtistas : Menu
{
    private readonly DAL<Artista> bandaDAL;

    public MenuRegistrarArtistas(DAL<Artista> bandaDAL)
    {
        this.bandaDAL = bandaDAL;
    }

    public override void Executar()
    {
        ExibirTitulos("Registro de Artistas/Artista");

        Console.Write("Digite o nome do artista ou Artista: ");
        string nome = Console.ReadLine()!;

        Console.Write("Digite a bio do artista /n" +
            "(ou digite OK, caso não queira escrever a bio): ");
        string bio = Console.ReadLine()!;

        if (bio.Equals("ok", StringComparison.OrdinalIgnoreCase))
        {
            bio = "Sem bio!";
        }
        else
        {
            Console.WriteLine("Digite OK para continuar sem bio.");
            Console.ReadKey();
            return; // sai do Executar e volta ao menu
        }
    }
}
