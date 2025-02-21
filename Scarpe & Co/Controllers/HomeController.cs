
using Microsoft.AspNetCore.Mvc;
using ScarpeECo.Data;

namespace ScarpeECo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ShoeRepository _shoeRepository;

        public HomeController(ShoeRepository shoeRepository)
        {
            _shoeRepository = shoeRepository;
        }

        public IActionResult Index()
        {
            var shoes = _shoeRepository.GetShoesAsync().Result;
            return View(shoes);
        }

        public async Task<IActionResult> Details(string id)
        {
            var shoe = await _shoeRepository.GetByIdAsync(id);
            if (shoe == null)
                return NotFound();
            return View(shoe);
        }
    }
}

