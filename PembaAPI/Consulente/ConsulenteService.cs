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

    }
}