using AutoMapper;
using BoardGameHub.Core.DTOs.Shop.Response;
using BoardGameHub.ViewModel.ShopModels;

namespace BoardGameHub.Mapping
{
    public class WebShopProfile : Profile
    {   
        public WebShopProfile()
        {
            CreateMap<ShopIndexResponse, ShopIndex>();
        }
    }
}
