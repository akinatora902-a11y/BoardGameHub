using AutoMapper;
using BoardGameHub.Core.Contracts;
using BoardGameHub.Core.DTOs.Shop.Request;
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

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var shopFormRespons = await shopServices.CreateShopFormAsync();
            var shopForm = mapper.Map<CreateShop>(shopFormRespons);

            return View(shopForm);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateShopRequest response)
        {
            var shopFormReques = await shopServices.CrateShopAsync(response);
            var newShop = mapper.Map<CreateShop>(shopFormReques);

            return RedirectToAction("Index", "Shop");
        }
    }
}
