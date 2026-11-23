using BoardGameHub.Core.DTOs.Tournament.Response;

namespace BoardGameHub.Core.DTOs.Shop.Response
{
    public class ShopDetailResponse
    {
        public string Description { get; set; } = null!;
        public IEnumerable<TournamentIndexResponse> Tournaments { get; set; }
        = new List<TournamentIndexResponse>();
    }
}
