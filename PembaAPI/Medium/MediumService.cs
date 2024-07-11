using System.Text;
using System.Text.Json;

namespace PembaAPI.Medium
{
    public static class MediumService
    {
        public static readonly HttpClient _httpClient = new HttpClient();

        public static async Task<List<MediumDTO>> BuscarTodosMedium()
        {
            string url = "https://localhost:44325/api/Medium";
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var results = JsonSerializer.Deserialize<List<MediumDTO>>(responseBody);

            return results;
        }
        public static async Task<MediumDTO> BuscarPorIdMedium(int id)
        {
            string url = "https://localhost:44325/api/Medium/{id}";
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var consulente = JsonSerializer.Deserialize<MediumDTO>(responseBody);

            return consulente;
        }
        public static async Task<MediumDTO> CriarMedium(MediumDTO novoMedium)
        {
            string url = "https://localhost:44325/api/Medium";
            var json = JsonSerializer.Serialize(novoMedium);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var mediumCriado = JsonSerializer.Deserialize<MediumDTO>(responseBody);

            return mediumCriado;
        }

        public static async Task<MediumDTO> AtualizarConsulente(MediumDTO mediumAtualizado)
        {
            string url = "https://localhost:44325/api/Medium/{mediumAtualizado.Id}";
            var json = JsonSerializer.Serialize(mediumAtualizado);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PutAsync(url, content);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(responseBody))
            {
                return mediumAtualizado;
            }

            else
            {
                var medium = JsonSerializer.Deserialize<MediumDTO>(responseBody);
                return medium;
            }

        }

        public static async Task<bool> DeletarMedium(int id)
        {
            string url = "https://localhost:44325/api/Medium/{id}";
            HttpResponseMessage response = await _httpClient.DeleteAsync(url);
            response.EnsureSuccessStatusCode();

            return response.IsSuccessStatusCode;
        }
    }
}
