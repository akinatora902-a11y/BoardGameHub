using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BoardGameHub.Common.Entity.Const.ShopConst;

namespace BoardGameHub.Data.Models
{
    [Comment("Shop in the system")]
    public class Shop
    {
        [Comment("Shop Identifier")]
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Comment("Shop Name")]
        [Required]
        [StringLength(ShopNameMaxLen, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; } = null!;

        [Comment("Shop Description")]
        [Required]
        [StringLength(ShopDescriptionMaxLen, ErrorMessage = "Description cannot exceed 1000 characters.")]
        public string Description { get; set; } = null!;
        
        [Comment("Approval Status Description")]
        [Required]
        public bool ApprovalStatus {  get; set; } = false;

        [Comment("Owner Description")]
        [Required]
        [StringLength(ShopOwnerMaxLen, ErrorMessage = "Owner cannot exceed 50 characters.")]
        public string Owner {  get; set; } = null!;

        [Comment("Identifier of the Identity user who owns the shop")]
        public string? OwnerId { get; set; }

        [ForeignKey(nameof(OwnerId))]
        public IdentityUser? OwnerUser { get; set; }
    }
}
