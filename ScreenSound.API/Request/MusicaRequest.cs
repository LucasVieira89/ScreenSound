using System.ComponentModel.DataAnnotations;

namespace ScreenSound.API.Request;

public record class MusicaRequest([Required] string nome, [Required] int ArtistaId, int anoLancamento, ICollection<GeneroRequest> Generos = null);