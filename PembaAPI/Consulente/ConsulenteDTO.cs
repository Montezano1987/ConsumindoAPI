

using System.Text.Json.Serialization;

namespace PembaAPI.Consulente
{
    public class ConsulenteDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("dataCadastro")]
        public DateTime DataCadastro { get; set; }

        [JsonPropertyName("dataNascimento")]
        public DateTime DataNascimento { get; set; }

        [JsonPropertyName("ehPrioritario")]
        public bool EhPrioritario { get; set; }

        [JsonPropertyName("ehMedium")]
        public bool EhMedium { get; set; }

    }
}
