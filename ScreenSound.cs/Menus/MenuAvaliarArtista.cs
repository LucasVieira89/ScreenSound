
using SS.Banco;
using ScreenSound.Models;

namespace TrabalhoC.Menus;

internal class MenuAvaliarArtista : Menu
    //quando foi feito deixei as variaveis todas como banda, alterar isso depois
{
    private readonly Dictionary<string, Artista>? bandasRegistradas;
    private readonly DAL<Musica>? MusicaDal;

    public override void Executar()
    { 
    ExibirTitulos("Avaliação de Artista");
    Console.Write("Digite o nome da Artista que você deseja avaliar");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.TryGetValue(nomeDaBanda, out Artista? value))
    {
        Console.Write($"Qual nota {nomeDaBanda} merece?");
            int valorNota = int.Parse(Console.ReadLine()!);
            Avaliacao nota = new Avaliacao(valorNota);
            value.AdicionarNota(nota);
    Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para {nomeDaBanda}!");
        Thread.Sleep(2000);
            Console.Clear();
}
    else
    {
        Console.WriteLine($"\nA Artista {nomeDaBanda} não foi encontrada");
        Console.WriteLine("Digite qualquer tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}
}
