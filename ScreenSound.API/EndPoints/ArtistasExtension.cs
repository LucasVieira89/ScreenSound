using SS.Banco;
using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Reponse;
using ScreenSound.API.Request;
using ScreenSound.Models;
using System.Collections;

namespace ScreenSound.API.EndPoints;

public static  class ArtistasExtension
{
    public static void AddEndPointsArtistas(this WebApplication app)
    {
        #region Endpoint Artistas
        app.MapGet("/Artistas", ([FromServices] DAL<Artista> dal) =>
        {
            var lista = dal.Listar();
            var response = EntityListToResponseList(lista);

            return Results.Ok(response);
        });

        app.MapGet("/Artistas/{nome}", ([FromServices] DAL<Artista> dal, string nome) =>
        {
            var artista = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
            if (artista is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(artista);

        });

        app.MapPost("/Artistas", ([FromServices] DAL<Artista> dal, [FromBody] ArtistaRequest artistarequest) =>
        {
            var artista = new Artista(artistarequest.nome, artistarequest.bio);

            dal.Adicionar(artista);
            return Results.Ok();
        });

        app.MapDelete("/Artistas/{id}", ([FromServices] DAL<Artista> dal, int id) =>
        {
            var artista = dal.RecuperarPor(a => a.Id == id);
            if (artista is null)
            {
                return Results.NotFound();
            }
            dal.Deletar(artista);
            return Results.NoContent();

        });

        app.MapPut("/Artistas", ([FromServices] DAL<Artista> dal, [FromBody] ArtistaRequestEdit request) =>
        {
            var artistaAtt = dal.RecuperarPor(a => a.Id == request.Id);

            if (artistaAtt is null)
            {
                return Results.NotFound();
            }

            artistaAtt.Nome = request.nome;
            artistaAtt.Bio = request.bio;

            dal.Atualizar(artistaAtt);

            return Results.Ok();
        });
    }

        private static ICollection<ArtistaResponse> EntityListToResponseList(IEnumerable<Artista> listaDeArtistas)
    {
        return listaDeArtistas
            .Select(a => EntityToResponse(a))
            .ToList();
    }

    private static ArtistaResponse EntityToResponse(Artista artista)
    {
        return new ArtistaResponse(
            artista.Id,
            artista.Nome,
            artista.Bio,
            artista.FotoPerfil
        );
    }
        #endregion
}

