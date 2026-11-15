using BoardGameHub.Core.DTOs.Shop.Request;
using BoardGameHub.Core.DTOs.Shop.Response;

namespace BoardGameHub.Core.Contracts
{
    public interface IShopServices
    {
        Task<IEnumerable<ShopIndexResponse>> ShopIndexAsync();

        Task<CreateShopRequest> CreateShopFormAsync();
    }
}
