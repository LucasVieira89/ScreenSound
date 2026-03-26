
using SS.Banco;
using ScreenSound.Models;

namespace TrabalhoC.Menus;

public abstract class Menu
{
    public void ExibirTitulos(string titulo)
    {
        int quantidadeDeLetras = titulo.Length;
        string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
        Console.WriteLine(asteriscos);
        Console.WriteLine(titulo);
        Console.WriteLine(asteriscos + "\n");
    }
        public abstract void Executar();

}
