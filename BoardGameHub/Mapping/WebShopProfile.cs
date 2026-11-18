using AutoMapper;
using BoardGameHub.Core.DTOs.Shop.Request;
using BoardGameHub.Core.DTOs.Shop.Response;
using BoardGameHub.ViewModel.ShopModels;

namespace BoardGameHub.Mapping
{
    public class WebShopProfile : Profile
    {   
        public WebShopProfile()
        {
            CreateMap<ShopIndexResponse, ShopIndex>();
            CreateMap<CreateShopRequest, CreateShop>();
            CreateMap<CreateShopResponse, CreateShop>();
        }
    }
}
