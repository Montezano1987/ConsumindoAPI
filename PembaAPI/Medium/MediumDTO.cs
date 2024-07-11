
using System.Text.Json.Serialization;

public class MediumDTO
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("nomeMedium")]
    public string NomeMedium { get; set; }

    [JsonPropertyName("dataCadastro")]
    public DateTime DataCadastro { get; set; }

    [JsonPropertyName("dataNascimento")]
    public DateTime DataNascimento { get; set; }

    [JsonPropertyName("qtdConsultasMaxDiarias")]
    public int QtdConsultasMaxDiarias { get; set; }

    [JsonPropertyName("lado")]
    public string? Lado { get; set; }

    [JsonPropertyName("ordem")]
    public int? Ordem { get; set; }
}

