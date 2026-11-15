using BoardGameHub.Core.Contracts;
using BoardGameHub.Core.DTOs.Shop.Request;
using BoardGameHub.Core.DTOs.Shop.Response;
using BoardGameHub.Data;
using Microsoft.EntityFrameworkCore;

namespace BoardGameHub.Core.Services
{
    public class ShopServices(BoardGameHubDbContext dbContext) : IShopServices
    {
        public async Task<CreateShopRequest> CreateShopFormAsync()
        {
            var shopForm = new CreateShopRequest();

            return shopForm;
        }

        public async Task<IEnumerable<ShopIndexResponse>> ShopIndexAsync()
        {
            var allShops = await dbContext.Shop
                .OrderBy(sh => sh.Id)
                .ThenBy(sh => sh.Name)
                .Select(s => new ShopIndexResponse
                {
                    Id = s.Id,
                    Name = s.Name,
                })
                .ToArrayAsync();

            return allShops;
        }
    }
}
