using System.ComponentModel.DataAnnotations;
using static BoardGameHub.Common.Application.Const.ApplicationConst;

namespace BoardGameHub.Models.ShopModels
{
    public class CreateShop
    {
        [Required(ErrorMessage = "Description is required.")]
        [StringLength(shopDescriptionMaxLen, MinimumLength = shopDescriptionMinLen, ErrorMessage = "Description must be between {2} and {1} characters.")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(shopNameMaxLen, MinimumLength = applicationConstMinimumLength, ErrorMessage = "Name must be between {2} and {1} characters.")]
        public string Name { get; set; } = null!;
    }
}
