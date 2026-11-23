using AutoMapper;
using AutoMapper.QueryableExtensions;
using BoardGameHub.Core.Contracts;
using BoardGameHub.Core.DTOs.Shop.Response;
using BoardGameHub.Core.DTOs.Tournament.Response;
using BoardGameHub.Data;
using Microsoft.EntityFrameworkCore;

namespace BoardGameHub.Core.Services
{
    public class TournamentServices(BoardGameHubDbContext dbContext, IMapper mapper) : ITournamentServices
    {
        public async Task<IEnumerable<TournamentIndexResponse>> TournamentsIndexAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException(nameof(id));

            return await dbContext.Tournament
                .Where(t => t.ShopId == id)
                .ProjectTo<TournamentIndexResponse>(mapper.ConfigurationProvider)
                .ToArrayAsync();
        }
    }
}
