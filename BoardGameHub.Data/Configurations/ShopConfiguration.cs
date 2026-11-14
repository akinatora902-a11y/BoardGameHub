using Microsoft.EntityFrameworkCore;
using BoardGameHub.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace BoardGameHub.Data.Configurations
{
    public class ShopConfiguration : IEntityTypeConfiguration<Shop>
    {
        public void Configure(EntityTypeBuilder<Shop> builder)
        {
            builder.HasData(
               new Shop
               {
                   Id = Guid.Parse("b0000000-0000-0000-0000-000000000001"),
                   Name = "Dice & Dragons",
                   Description = "Board game store and play space in the city center.",
                   ApprovalStatus = true,
                   Owner = "Ivan Petrov"
               },
               new Shop
               {
                   Id = Guid.Parse("b0000000-0000-0000-0000-000000000002"),
                   Name = "Meeple Corner",
                   Description = "Cozy cafe with a large collection of board games.",
                   ApprovalStatus = true,
                   Owner = "Maria Georgieva"
               },
               new Shop
               {
                   Id = Guid.Parse("b0000000-0000-0000-0000-000000000003"),
                   Name = "Tabletop Club",
                   Description = "Community club that hosts weekly game nights.",
                   ApprovalStatus = false,
                   Owner = "Georgi Dimitrov"
               }
           );
        }
    }
}
