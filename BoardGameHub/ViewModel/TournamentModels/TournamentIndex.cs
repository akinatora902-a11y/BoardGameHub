using BoardGameHub.Core.DTOs.Tournament.Response;

namespace BoardGameHub.ViewModel.TournamentModels
{
    public class TournamentIndex
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDateAndTime { get; set; }
        public bool Status { get; set; }
        public Guid GameId { get; set; }
        public IEnumerable<TournamentIndexResponse> Tournaments { get; set; }
            = new List<TournamentIndexResponse>();
    }
}
