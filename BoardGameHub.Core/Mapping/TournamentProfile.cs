using AutoMapper;
using BoardGameHub.Core.DTOs.Tournament.Response;
using BoardGameHub.Data.Models;


namespace BoardGameHub.Core.Mapping
{
    public class TournamentProfile : Profile
    {
        public TournamentProfile() 
        {
            CreateMap<Tournament, TournamentIndexResponse>();
        }
    }
}
