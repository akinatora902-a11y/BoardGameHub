using AutoMapper;
using BoardGameHub.Core.DTOs.Admin.Response;
using BoardGameHub.Data.Models;

namespace BoardGameHub.Core.Mapping
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<Shop, AdminIndexResponse>();
        }
    }
}
