using AutoMapper;
using AutoMapper.QueryableExtensions;
using BoardGameHub.Core.Contracts;
using BoardGameHub.Core.DTOs.Shop.Request;
using BoardGameHub.Core.DTOs.Shop.Response;
using BoardGameHub.Data;
using Microsoft.EntityFrameworkCore;

namespace BoardGameHub.Core.Services
{
    public class ShopServices(BoardGameHubDbContext dbContext, IMapper mapper) : IShopServices
    {
        public async Task<CreateShopRequest> CreateShopFormAsync()
        {
            var shopForm = new CreateShopRequest();

            return shopForm;
        }

        public async Task<IEnumerable<ShopIndexResponse>> ShopIndexAsync()
        {
            var allShops = await dbContext.Shop
                .OrderBy(sh => sh.Name)
                .ProjectTo<ShopIndexResponse>(mapper.ConfigurationProvider)
                .ToArrayAsync();

            return allShops;
        }
    }
}
