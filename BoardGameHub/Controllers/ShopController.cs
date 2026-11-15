using AutoMapper;
using BoardGameHub.Core.Contracts;
using BoardGameHub.ViewModel.ShopModels;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameHub.Controllers
{
    public class ShopController(IShopServices shopServices, IMapper mapper) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var allShopsResponse = await shopServices.ShopIndexAsync();
            var allShopsViewModel = mapper.Map<IEnumerable<ShopIndex>>(allShopsResponse);

            return View(allShopsViewModel);
        }
    }
}
