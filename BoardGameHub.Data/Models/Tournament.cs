using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BoardGameHub.Common.Entity.Const.Tournament;

namespace BoardGameHub.Data.Models
{
    [Comment("Tournament in the system")]
    public class Tournament
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [Comment("Tournament Title.")]
        [MaxLength(TournamentTitleMaxLen, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; } = null!;

        [Required]
        [Comment("Start date and time for tournament starts.")]
        public DateTime StartDateAndTime { get; set; }

        [Required]
        [Comment("Max participants in the tournament.")]
        public int MaxParticipants { get; set; }

        [Required]
        [Comment("Tournament Description.")]
        [MaxLength(TournamentDescriptionMaxLen, ErrorMessage = "Tournament description cannot exceed 500 characters.")]
        public string Description { get; set; } = null!;

        [Required]
        [Comment("Current status of the tournament.")]
        public bool Status { get; set; }

        [Required]
        [Comment("Foreign Key to the organizing Shop.")]
        public Guid ShopId { get; set; }

        [ForeignKey(nameof(ShopId))]
        public Shop Shop { get; set; } = null!;

        [Required]
        [Comment("Foreign Key to the Game being played.")]
        public Guid GameId { get; set; }

        [ForeignKey(nameof(GameId))]
        public Game Game { get; set; } = null!;

        public ICollection<TournamentRegistration> TournamentRegistrations { get; set; } = new HashSet<TournamentRegistration>();
    }
}
