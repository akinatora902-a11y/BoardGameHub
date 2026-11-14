using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static BoardGameHub.Common.Entity.Const.Game;

namespace BoardGameHub.Data.Models
{
    [Comment("Game in the system")]
    public class Game
    {
        [Key]
        public Guid Id {  get; set; } = Guid.NewGuid();
        
        [Required]
        [Comment("Game Name")]
        [StringLength(GameNameMaxLen, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; } = null!;
        
        [Required]
        [Comment("Game Max Participants")]
        public int MaxParticipants { get; set; }
        
        [Required]
        [Comment("Game Min Participants")]
        public int MinParticipants {  get; set; }

        [Required]
        [Comment("Game Category Id")]
        public Guid CategoryId { get; set; }

        [Required]
        [Comment("Game Category")]
        public Category Category {  get; set; }
    }
}
