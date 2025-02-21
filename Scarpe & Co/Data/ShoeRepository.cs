
//62cc9e79-4ce1-432a-8e55-e301cb512402

using System.Text.Json;
namespace ScarpeECo.Data
{
    public class ShoeRepository
    {
        private readonly HttpClient _httpClient;
        private const string ApiUrl = "https://app.retailed.io/api/v1/db/products";
        private const string ApiKey = "62cc9e79-4ce1-432a-8e55-e301cb512402";

        public ShoeRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Shoe>> GetShoesAsync()
        {
            _httpClient.DefaultRequestHeaders.Add("x-api-key", ApiKey);
            var response = await _httpClient.GetStringAsync(ApiUrl);
            var data = JsonSerializer.Deserialize<ApiResponse>(response);
            return data?.Products ?? new List<Shoe>();
        }
        public async Task<Shoe?> GetByIdAsync(string id)
        {
            var allShoes = await GetShoesAsync();
            return allShoes.FirstOrDefault(s => s.Id == id);
        }


        public async Task<List<Shoe>> GetNikeShoesAsync()
        {
            var allShoes = await GetShoesAsync();
            return allShoes.Where(s => s.Brand?.ToLower() == "nike").ToList();
        }
    }

    public class ApiResponse
    {
        public List<Shoe> Products { get; set; }
    }

    public class Shoe
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
