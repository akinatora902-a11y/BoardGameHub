namespace BoardGameHub.Core.DTOs.Tournament.Response
{
    public class TournamentIndexResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set;}
        public DateTime StartDateAndTime { get; set;}
        public bool Status { get; set;}
        public Guid GameId { get; set;}

    }
}
