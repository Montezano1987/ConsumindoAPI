using System.Text;
using System.Text.Json;

namespace PembaAPI.Consulente
{
    public static class ConsulenteService
    {
        public static readonly HttpClient _httpClient = new HttpClient();

        public static async Task<List<ConsulenteDTO>> BuscarTodosConsulente()
        {
            string url = "https://localhost:44325/api/Consulente";
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var results = JsonSerializer.Deserialize<List<ConsulenteDTO>>(responseBody);

            return results;
        }
        public static async Task<ConsulenteDTO> BuscarPorIdConsulente(int id)
        {
            string url = $"https://localhost:44325/api/Consulente/{id}";
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var consulente = JsonSerializer.Deserialize<ConsulenteDTO>(responseBody);

            return consulente;
        }
        public static async Task<ConsulenteDTO> CriarConsulente(ConsulenteDTO novoConsulente)
        {
            string url = "https://localhost:44325/api/Consulente";
            var json = JsonSerializer.Serialize(novoConsulente);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var consulenteCriado = JsonSerializer.Deserialize<ConsulenteDTO>(responseBody);
            
            return consulenteCriado;
        }

        public static async Task<ConsulenteDTO> AtualizarConsulente(ConsulenteDTO consulenteAtualizado)
        {
            string url = $"https://localhost:44325/api/Consulente/{consulenteAtualizado.Id}";
            var json = JsonSerializer.Serialize(consulenteAtualizado);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PutAsync(url, content);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(responseBody))
            {
                return consulenteAtualizado;
            }

            else
            {
                var consulente = JsonSerializer.Deserialize<ConsulenteDTO>(responseBody);
                return consulente;
            }
            
        }

        public static async Task<bool> DeletarConsulente(int id)
        {
            string url = $"https://localhost:44325/api/Consulente/{id}";
            HttpResponseMessage response = await _httpClient.DeleteAsync(url);
            response.EnsureSuccessStatusCode();

            return response.IsSuccessStatusCode;
        }
    }
}
