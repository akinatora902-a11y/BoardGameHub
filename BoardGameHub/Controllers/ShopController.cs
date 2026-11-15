using BoardGameHub.Core.Contracts;
using BoardGameHub.Core.DTOs.Shop.Response;
using BoardGameHub.Data;
using BoardGameHub.ViewModel.ShopModels;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameHub.Controllers
{
    public class ShopController(IShopServices shopServices) : Controller
    {
        public async Task<IActionResult> Index()
        {
            IEnumerable<ShopIndexResponse> allShopsResponse = await shopServices.ShopIndexAsync();

            IEnumerable<ShopIndex> allShopsViewModel = allShopsResponse
                .Select(s => new ShopIndex
                {
                    Id = s.Id,
                    Name = s.Name,
                })
                .ToArray();

            return View(allShopsViewModel);
        }
    }
}
