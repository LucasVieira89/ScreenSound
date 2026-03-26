using SS.Banco;
using SS.Menus;
using Microsoft.EntityFrameworkCore;
using ScreenSound;
using ScreenSound.Models;
using System;
using TrabalhoC.Menus;

var options = new DbContextOptionsBuilder<ScreenSoundContext>()
    .UseSqlServer("Server=localhost;Database=ScreenSoundNovo;Trusted_Connection=True;TrustServerCertificate=True;")
    .Options;

var context = new ScreenSoundContext(options); 
DAL<Artista> bandaDAL = new DAL<Artista>(context);
DAL<Musica> musicaDAL = new DAL<Musica>(context);

Dictionary<string, Artista> bandasRegistradas = new Dictionary<string, Artista>();
Artista ThalesRoberto = new Artista("Thales Roberto");
ThalesRoberto.AdicionarNota(new Avaliacao(10));
ThalesRoberto.AdicionarNota(new Avaliacao(10));
ThalesRoberto.AdicionarNota(new Avaliacao(6));
Artista Skillet = new Artista("Skillet");
Skillet.AdicionarNota(new Avaliacao(8));
Skillet.AdicionarNota(new Avaliacao(9));
Skillet.AdicionarNota(new Avaliacao(7));

//List<string> listaDasBandas = new List<string> {"Linkin Park", "All Time Low","Iron Maiden","The Beatles","Projeto Sola"};;  
//bandasRegistradas.Add(ThalesRoberto.Nome, ThalesRoberto);
//bandasRegistradas.Add(Skillet.Nome, Skillet);

Dictionary<int, Menu> opcoes = new();
opcoes.Add(1, new MenuRegistrarArtistas(bandaDAL));
opcoes.Add(2, new MenuMostrarArtistas(bandaDAL));
opcoes.Add(3, new MenuRegistrarAlbum());
opcoes.Add(4, new MenuAvaliarArtista());
opcoes.Add(5, new MenuExibirDetalhes());
opcoes.Add(6, new MenuAvaliarAlbum());
opcoes.Add(7, new MenuMostrarMusicas(musicaDAL));
opcoes.Add(8, new MenuRegistrarMusica(bandasRegistradas));
opcoes.Add(0, new MenuSair());

void ExibirLogo()
{
    string mensagemDeBoasVindas = "Boas vindas ao Screen Sound";
    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine(mensagemDeBoasVindas);
}
void ExibirOpcoesDoMenu()
{
    Console.WriteLine("\nDigite 1 para registrar um Artista");
    Console.WriteLine("Digite 2 para mostrar todas as Banda e artistas");
    Console.WriteLine("Digite 3 para registrar um album");
    Console.WriteLine("Digite 4 para avaliar uma Artista");
    Console.WriteLine("Digite 5 para exibir os detalhes uma Artista");
    Console.WriteLine("Digite 6 para avaliar um album");
    Console.WriteLine("Digite 7 para exibir todas as musicas");
    Console.WriteLine("Digite 8 para registrar uma musica!");
    Console.WriteLine("Observação: Artistas = Bandas, então não tenha medo de registrar uma banda que você goste!");

    Console.WriteLine("\nDigite 0 para sair");
}
int escolha = -1;
do
{
    ExibirLogo();
    ExibirOpcoesDoMenu();

    Console.Write("Digite a sua escolha");
    string EscolhaNumerica = Console.ReadLine()!;
    if (!int.TryParse(EscolhaNumerica, out escolha))
    {
        Console.WriteLine("Opção inválida! Digite um número.");
        Console.ReadKey();
        return;
    }


    if (opcoes.ContainsKey(escolha))
    {
        Menu menuExibido = opcoes[escolha];
        menuExibido.Executar();
        if (escolha > 0) ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine("Opção invalida!");
    }
    ExibirOpcoesDoMenu();
}
while (escolha !=0);


Executar();

void Executar()
{
    Artista thalesRoberto = new Artista("Thalles Roberto");

    Album album = new Album("Na Sala do Pai");

    Musica musica1 = new Musica("Arde Outra Vez")
    {
        Duracao = 230,
        Disponivel = false
    };

    Musica musica2 = new Musica("Pai, eu não confio em mim")
    {
        Duracao = 250,
        Disponivel = true
    };

    album.AdicionarMusica(musica1);
    album.AdicionarMusica(musica2);

    thalesRoberto.AdicionarAlbum(album);


    Console.WriteLine($"Artista: {thalesRoberto.Nome}");
    foreach (var alb in thalesRoberto.Albuns)
    {
        Console.WriteLine($"Álbum: {alb.Nome}");
        foreach (var musica in alb.Musicas)
        {
            musica.ExibirFicha();
            Console.WriteLine();
        }
    }
}

//        switch (escolha)
//        {
//            case 1:
//                MenuRegistrarBanda menu1 = new MenuRegistrarBanda();
//                menu1.Executar(bandasRegistradas);
//                ExibirOpcoesDoMenu();
//                break;
//            case 2:
//                MenuExibirBanda menu2 = new MenuExibirBanda();
//                menu2.Executar(bandasRegistradas);
//                ExibirOpcoesDoMenu();
//                break;
//            case 3:
//                MenuRegistrarAlbum menu3 = new MenuRegistrarAlbum();
//                menu3.Executar(bandasRegistradas);
//                ExibirOpcoesDoMenu();
//                //CRIAR REGISTRAR ALBUM
//                break;
//            case 4:
//                MenuAvaliarBanda menu4 = new MenuAvaliarBanda();
//                menu4.Executar(bandasRegistradas);
//                ExibirOpcoesDoMenu();
//                break;
//            case 5:
//                MenuExibirDetalhes menu5 = new MenuExibirDetalhes();
//                menu5.Executar(bandasRegistradas);
//                ExibirOpcoesDoMenu();
//                break;
//            case 0:
//                Console.WriteLine("Até mais!");
//                break;
//            default:
//                Console.WriteLine("Opção inexistente");
//                break;
//        }
//}
//while (escolha != 0);
















