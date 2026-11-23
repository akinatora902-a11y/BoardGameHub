using BoardGameHub.Core.DTOs.Shop.Response;
using BoardGameHub.Core.DTOs.Tournament.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameHub.Core.Contracts
{
    public interface ITournamentServices
    {
        Task<IEnumerable<TournamentIndexResponse>> TournamentsIndexAsync(Guid id);
    }
}
