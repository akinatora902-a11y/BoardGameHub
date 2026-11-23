using AutoMapper;
using BoardGameHub.Core.DTOs.Tournament.Response;
using BoardGameHub.ViewModel.TournamentModels;

namespace BoardGameHub.Mapping
{
    public class TournamentWebProfile : Profile
    {
        public TournamentWebProfile() 
        {
            CreateMap<TournamentIndexResponse, TournamentIndex>();
        }
    }
}
