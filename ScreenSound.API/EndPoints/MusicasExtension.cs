using SS.Banco;
using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Reponse;
using ScreenSound.API.Request;
using ScreenSound.Models;

namespace ScreenSound.API.EndPoints;

public static class MusicasExtension
{
    public static void AddEndPointsMusicas(this WebApplication app)
    {
        #region Endpoint Músicas;
        app.MapGet("/Musicas", ([FromServices] DAL<Musica> dal) =>
        {
            return Results.Ok(dal.Listar());
        });

        app.MapGet("/Musicas/{nome}", ([FromServices] DAL<Musica> dal, string nome) =>
        {
            var musica = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
            if (musica is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(musica);

        });

        app.MapPost("/Musicas", ([FromServices] DAL<Musica> dal, [FromBody] MusicaRequest musicarequest,
            [FromServices] DAL<Genero> dalGenero) =>
        {
            var musica = new Musica(musicarequest.nome)
            {
                ArtistaId = musicarequest.ArtistaId,
                AnoDeLancamento = musicarequest.anoLancamento,
                Generos = musicarequest.Generos is not null ?
                GeneroRequestConverter(musicarequest.Generos, dalGenero) : new List<Genero>()
                //tentei usar if porém graças a lambda não é aceito dois argumentos
            };
            dal.Adicionar(musica);
            return Results.Ok();
        });

        app.MapDelete("/Musicas/{id}", ([FromServices] DAL<Musica> dal, int id) =>
        {
            var musica = dal.RecuperarPor(a => a.Id == id);
            if (musica is null)
            {
                return Results.NotFound();
            }
            dal.Deletar(musica);
            return Results.NoContent();

        });

        app.MapPut("/Musicas", ([FromServices] DAL<Musica> dal, [FromBody] Musica musica) =>
        {
            var musicaAtt = dal.RecuperarPor(a => a.Id == musica.Id);
            if (musicaAtt is null)
            {
                return Results.NotFound();
            }
            musicaAtt.Nome = musica.Nome;
            musicaAtt.AnoDeLancamento = musica.AnoDeLancamento;

            dal.Atualizar(musicaAtt);
            return Results.Ok();
        });
    }

    private static ICollection<Genero> GeneroRequestConverter(ICollection<GeneroRequest> generos, DAL<Genero> dalGenero)
    {
        var listaGenero = new List<Genero>();
        foreach (var item in generos)
        {
            var entity = RequestToEntity(item);
            var genero = dalGenero.RecuperarPor(g => g.Nome.ToUpper().Equals(item.Nome.ToUpper()));
            if (genero is not null)
            {
                listaGenero.Add(genero);
            }
            else
            {
                listaGenero.Add(entity);
            }
        }
        return listaGenero;
    }

    private static Genero RequestToEntity(GeneroRequest genero)
    {
        return new Genero() { Nome = genero.Nome, Descricao = genero.Descricao };
    }

    private static ICollection<MusicaResponse> EntityListToResponseList(IEnumerable<Musica> musicaList)
    {
        return musicaList.Select(a => EntityToResponse(a)).ToList();
    }

    private static MusicaResponse EntityToResponse(Musica musica)
    {
        return new MusicaResponse(musica.Id, musica.Nome!, musica.Artista!.Id, musica.Artista.Nome);
    }
        #endregion

};
