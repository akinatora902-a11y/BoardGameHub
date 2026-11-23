using BoardGameHub.Core.DTOs.Shop.Request;
using BoardGameHub.Core.DTOs.Shop.Response;

namespace BoardGameHub.Core.Contracts
{
    public interface IShopServices
    {
        Task<IEnumerable<ShopIndexResponse>> ShopIndexAsync();
        Task<CreateShopResponse> CrateShopAsync(CreateShopRequest response);
        Task<CreateShopRequest> CreateShopFormAsync();
        Task <bool> DeleteShopFormAsync(Guid? Id);
        Task<EditShopResponse> EditShopFormAsync(Guid? id); 
        Task<bool> EditShopRequestAsync(EditShopRequest request);
        Task <ShopDetailResponse> DetailAsync(Guid? id);
    }
}
