namespace ScreenSound.API.Request;

public record class MusicaRequestEdit(int Id, string nome, int ArtistaId, int AnoDeLancamento) : MusicaRequest(nome, ArtistaId, AnoDeLancamento);