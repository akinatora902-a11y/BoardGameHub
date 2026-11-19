using AutoMapper;
using BoardGameHub.Core.Contracts;
using BoardGameHub.Core.DTOs.Shop.Request;
using BoardGameHub.Core.DTOs.Shop.Response;
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

        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute] Guid? id) 
        {
            var shopForDelete = await shopServices.DeleteShopFormAsync(id);

            if (shopForDelete == false) 
            {
                return BadRequest();
            }

            return RedirectToAction("Index", "Shop");
        }

        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute] Guid? id)
        {
            var shopFormReques = await shopServices.EditShopFormAsync(id);
            var shopForEdit = mapper.Map<EditShop> (shopFormReques);

            return View(shopForEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditShop model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var request = mapper.Map<EditShopRequest>(model);
            var result = await shopServices.EditShopRequestAsync(request);

            if (!result) return NotFound();

            return RedirectToAction(nameof(Index));
        }
    }
}
