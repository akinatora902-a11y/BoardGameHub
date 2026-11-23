using BoardGameHub.ViewModel.TournamentModels;

namespace BoardGameHub.ViewModel.ShopModels
{
    public class ShopDetail
    {
        public string Description { get; set; }
        public IEnumerable<TournamentIndex> Tournaments { get; set; }
            = new List<TournamentIndex>();
    }
}
