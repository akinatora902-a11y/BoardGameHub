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

            CreateMap<CreateShopRequest, Shop>()
               .ForMember(d => d.Id, o => o.Ignore())
               .ForMember(d => d.ApprovalStatus, o => o.Ignore());

            CreateMap<Shop, CreateShopResponse>();

        }
    }
}
