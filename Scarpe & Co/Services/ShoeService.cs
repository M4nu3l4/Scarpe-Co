using ScarpeECo.Data;


namespace ScarpeECo.Services
{
    public class ShoeService
    {
        private readonly ShoeRepository _repository;

        public ShoeService(ShoeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Data.Shoe>> GetNikeShoesAsync()
        {
            var shoes = await _repository.GetNikeShoesAsync();

            return shoes.Select(s => new Data.Shoe
            {
                Id = s.Id,
                Title = s.Title,
                Brand = s.Brand,
                Description = s.Description,
                Url = s.Url,
                Price = s.Price,
                ImageUrl = s.ImageUrl
            }).ToList();
        }
    }
}




