using AutoMapper;
using BoardGameHub.Core.DTOs.Admin.Response;
using BoardGameHub.ViewModel.Admin;

namespace BoardGameHub.Mapping
{
    public class AdminWebProfile : Profile
    {
        public AdminWebProfile()
        {
            CreateMap<AdminIndexResponse, AdminIndex>();
        }
    }
}
