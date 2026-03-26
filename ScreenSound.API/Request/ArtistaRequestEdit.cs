namespace ScreenSound.API.Request;

public record class ArtistaRequestEdit(int Id, string nome, string bio): ArtistaRequest(nome, bio);
