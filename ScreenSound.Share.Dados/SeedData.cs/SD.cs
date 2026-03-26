using SS.Banco;
using Microsoft.EntityFrameworkCore;
using ScreenSound.Models;
using System.Text.Json;



public static class SD
{
    private class SongJson
    {
        public string? artist { get; set; }
        public string? song { get; set; }
    }

    public static async Task SeedDatabaseAsync(ScreenSoundContext context)
    {
        if (await context.Artistas.AnyAsync())
            return;

        var url = "https://guilhermeonrails.github.io/api-csharp-songs/songs.json";

        using var http = new HttpClient();
        var json = await http.GetStringAsync(url);

        var songs = JsonSerializer.Deserialize<List<SongJson>>(json,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        if (songs is null || songs.Count == 0)
            return;

        var grupos = songs
            .Where(s => !string.IsNullOrWhiteSpace(s.artist) && !string.IsNullOrWhiteSpace(s.song))
            .GroupBy(s => s.artist!.Trim());

        foreach (var grupo in grupos)
        {
            var artista = new Artista(grupo.Key);

            foreach (var item in grupo)
            {

                var musica = new Musica(item.song!);

                artista.Musicas.Add(musica);
            }

            context.Artistas.Add(artista);
        }

        await context.SaveChangesAsync();
    }
}
