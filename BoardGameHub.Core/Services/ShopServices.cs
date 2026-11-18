using AutoMapper;
using AutoMapper.QueryableExtensions;
using BoardGameHub.Core.Contracts;
using BoardGameHub.Core.DTOs.Shop.Request;
using BoardGameHub.Core.DTOs.Shop.Response;
using BoardGameHub.Data;
using BoardGameHub.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardGameHub.Core.Services
{
    public class ShopServices(BoardGameHubDbContext dbContext, IMapper mapper) : IShopServices
    {
        public async Task<CreateShopResponse> CrateShopAsync(CreateShopRequest response)
        {

            if (response == null)
            {
                throw new ArgumentException("The create shop request cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(response.Name)) 
            {
                throw new ArgumentException("The Name is request cannot be null/WhiteSpace.");
            }

            bool shopExist = await dbContext
                .Shop
                .AnyAsync(s  => s.Name == response.Name);

            if (shopExist) 
            {
                throw new ArgumentException("A shop with this name already exists.");
            }

            var newShop = mapper.Map<Shop>(response);

            try
            {
                dbContext.Shop.AddAsync(newShop);
                dbContext.SaveChangesAsync();

                var resultResponse = mapper.Map<CreateShopResponse>(newShop);
                return resultResponse;
            }
            catch (ArgumentException ex) 
            {
                throw new ArgumentException("An error occurred while creating the shop.", ex);
            }
            
        }

        public async Task<CreateShopRequest> CreateShopFormAsync()
        {
            var shopForm = new CreateShopRequest();

            return shopForm;
        }

        public async Task<bool> DeleteShopFormAsync(Guid? Id)
        {
            if (Id == Guid.Empty)
            {
                return false;
            }

            var shopIsExist = await dbContext
                .Shop
                .FindAsync(Id);

            if (shopIsExist == null)
            {
                return false;
            }

            try
            {
                dbContext.Shop.Remove(shopIsExist);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (ArgumentException ex) 
            {
                return false;
            }
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
