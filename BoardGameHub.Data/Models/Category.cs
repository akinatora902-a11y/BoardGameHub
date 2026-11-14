using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static BoardGameHub.Common.Entity.Const.Category;

namespace BoardGameHub.Data.Models
{
    [Comment("Category Registration in the system")]
    public class Category
    {
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [StringLength(CategoryNameMaxLen, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }
    }
}
