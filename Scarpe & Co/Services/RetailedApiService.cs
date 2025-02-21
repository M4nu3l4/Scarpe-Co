
using System.Text.Json;
using Scarpe___Co.Models; 

namespace ScarpeECo.Services
{
    public class RetailedApiService
    {
        private readonly HttpClient _httpClient;
        private const string ApiUrl = "https://app.retailed.io/api/v1/db/products";
        private const string ApiKey = "9e68571e-34b3-4ba3-8c4e-00f665138246";

        public RetailedApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Shoe>> GetShoesAsync() 
        {
            _httpClient.DefaultRequestHeaders.Add("x-api-key", ApiKey);
            var response = await _httpClient.GetStringAsync(ApiUrl);
            var jsonDocument = JsonDocument.Parse(response);

            List<Shoe> shoes = new List<Shoe>();
            foreach (var item in jsonDocument.RootElement.GetProperty("products").EnumerateArray())
            {
                shoes.Add(new Shoe
                {
                    Id = item.GetProperty("id").GetString(),
                    Title = item.GetProperty("title").GetString(),
                    Brand = item.GetProperty("brand").GetString(),
                    Category = item.GetProperty("category").GetString(),
                    Size = item.GetProperty("size").GetString(),
                    Description = item.GetProperty("description").GetString(),
                    Price = item.GetProperty("price").GetDecimal(),
                    ImageUrl = item.GetProperty("images.id").GetString()
                });
            }
            return shoes;
        }
    }
}


