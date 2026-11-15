using BoardGameHub.Core.Contracts;
using BoardGameHub.Core.DTOs.Shop.Request;
using BoardGameHub.Core.DTOs.Shop.Response;
using BoardGameHub.Data;
using Microsoft.EntityFrameworkCore;

namespace BoardGameHub.Core.Services
{
    public class ShopServices(BoardGameHubDbContext dbContext) : IShopServices
    {
        public async Task<IEnumerable<ShopIndexResponse>> ShopIndexAsync()
        {
            var allShops = await dbContext.Shop
                .Select(s => new ShopIndexResponse
                {
                    Id = s.Id,
                    Description = s.Description,
                    Name = s.Name,
                    Owner = s.Owner,
                })
                .ToArrayAsync();

            return allShops;
        }
    }
}
