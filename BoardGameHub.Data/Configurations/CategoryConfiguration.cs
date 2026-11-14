using Microsoft.EntityFrameworkCore;
using BoardGameHub.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace BoardGameHub.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category
                {
                    Id = Guid.Parse("c0000000-0000-0000-0000-000000000001"),
                    Name = "Strategy"
                },
                new Category
                {
                    Id = Guid.Parse("c0000000-0000-0000-0000-000000000002"),
                    Name = "Party"
                },
                new Category
                {
                    Id = Guid.Parse("c0000000-0000-0000-0000-000000000003"),
                    Name = "Card Games"
                },
                new Category
                {
                    Id = Guid.Parse("c0000000-0000-0000-0000-000000000004"),
                    Name = "Cooperative"
                }
            );
        }
    }
}
