using AutoMapper;
using AutoMapper.QueryableExtensions;
using BoardGameHub.Common.Entity.Const;
using BoardGameHub.Core.Contracts;
using BoardGameHub.Core.DTOs.Shop.Request;
using BoardGameHub.Core.DTOs.Shop.Response;
using BoardGameHub.Data;
using BoardGameHub.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BoardGameHub.Core.Services
{
    public class ShopServices(BoardGameHubDbContext dbContext, IMapper mapper, ITournamentServices tournamentServices) : IShopServices
    {
        public async Task<CreateShopResponse> CrateShopAsync(CreateShopRequest response)
        {

            if (response == null)
            {
                throw new ArgumentException("The create shop request cannot be null.");
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
                await dbContext.Shop.AddAsync(newShop);
                await dbContext.SaveChangesAsync();

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
        public async Task<ShopDetailResponse> DetailAsync(Guid? id)
        {

            if (id == null || id == Guid.Empty)
            {
                return null;
            }

            var shop = await dbContext.Shop
                .Where(shop => shop.Id == id)
                .ProjectTo<ShopDetailResponse>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            shop.Tournaments = (await tournamentServices.TournamentsIndexAsync(id.Value))
                .ToList();
            return shop;
                
        }
        public async Task<EditShopResponse> EditShopFormAsync(Guid? id)
        {
            var shopExist = await dbContext.Shop.FindAsync(id);
            if (shopExist == null)
            {
                throw new ArgumentException("");
            }

           var shop = await dbContext.Shop
                .Where(s => s.Id == id)
                .ProjectTo<EditShopResponse>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();


            return shop;
        }
        public async Task<bool> EditShopRequestAsync(EditShopRequest request)
        {
            var shop = await dbContext.Shop.FindAsync(request.Id);

            if (shop == null)
            {
                throw new ArgumentException($"Shop with id {request.Id} not found");
            }

            mapper.Map(request, shop);

            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<SearchRequest> SearchAsync(SearchRequest request)
        {
            var search = dbContext.Shop
                .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                search = search
                    .Where(s => s.Name.Contains(request.Name));
            }

            var searchShop = await search
                .ProjectTo<SearchRequest>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            return searchShop;
        }

        public async Task<IEnumerable<ShopIndexResponse>> ShopIndexAsync()
        {
            var allShops = await dbContext.Shop
                .Where(s => s.ApprovalStatus)
                .OrderBy(sh => sh.Name)
                .ProjectTo<ShopIndexResponse>(mapper.ConfigurationProvider)
                .ToArrayAsync();

            return allShops;
        }
    }
}
