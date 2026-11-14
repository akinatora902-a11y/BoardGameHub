using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameHub.Data.Models
{
    [Comment("Tournament Registration in the system")]
    [PrimaryKey(nameof(UserId), nameof(TournamentId))]
    public class TournamentRegistration
    {
        [Required]
        [Comment("Foreign Key to the User.")]
        public string UserId { get; set; } = null!; 

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        [Required]
        [Comment("Foreign Key to the Tournament.")]
        public Guid TournamentId { get; set; } 

        [ForeignKey(nameof(TournamentId))]
        public Tournament Tournament { get; set; } = null!;

        [Required]
        [Comment("Date and time when the user registered.")]
        public DateTime RegistrationDate { get; set; }
    }
}
