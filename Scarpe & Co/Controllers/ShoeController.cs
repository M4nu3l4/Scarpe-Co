using Microsoft.AspNetCore.Mvc;
using ScarpeECo.Data;


namespace ScarpeECo.Controllers
{
    public class ShoeController : Controller
    {
        private readonly ShoeRepository _shoeRepository;

        public ShoeController(ShoeRepository shoeRepository)
        {
            _shoeRepository = shoeRepository;
        }

        public async Task<IActionResult> Index()
        {
            var nikeShoes = await _shoeRepository.GetNikeShoesAsync();
            return View(nikeShoes);
        }
    }
}




