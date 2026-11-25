using AutoMapper;
using BoardGameHub.Core.DTOs.Shop.Request;
using BoardGameHub.Core.DTOs.Shop.Response;
using BoardGameHub.Data.Models;

namespace BoardGameHub.Core.Mapping
{
    public class ShopProfile : Profile
    {
        public ShopProfile()
        {
            CreateMap<Shop, ShopIndexResponse>();

            CreateMap<CreateShopRequest, Shop>();

            CreateMap<Shop, CreateShopResponse>();
            CreateMap<Shop, EditShopResponse>();
            CreateMap<EditShopRequest, Shop>();
            CreateMap<Shop,ShopDetailResponse>();

            CreateMap<Shop, SearchRequest>();

        }
    }
}
