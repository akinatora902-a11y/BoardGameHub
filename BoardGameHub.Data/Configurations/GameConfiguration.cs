using Microsoft.EntityFrameworkCore;
using BoardGameHub.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace BoardGameHub.Data.Configurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasData(
                new Game
                {
                    Id = Guid.Parse("a0000000-0000-0000-0000-000000000001"),
                    Name = "Catan",
                    MinParticipants = 3,
                    MaxParticipants = 4,
                    CategoryId = Guid.Parse("c0000000-0000-0000-0000-000000000001")
                },
                new Game
                {
                    Id = Guid.Parse("a0000000-0000-0000-0000-000000000002"),
                    Name = "Carcassonne",
                    MinParticipants = 2,
                    MaxParticipants = 5,
                    CategoryId = Guid.Parse("c0000000-0000-0000-0000-000000000001")
                },
                new Game
                {
                    Id = Guid.Parse("a0000000-0000-0000-0000-000000000003"),
                    Name = "Codenames",
                    MinParticipants = 4,
                    MaxParticipants = 8,
                    CategoryId = Guid.Parse("c0000000-0000-0000-0000-000000000002")
                },
                new Game
                {
                    Id = Guid.Parse("a0000000-0000-0000-0000-000000000004"),
                    Name = "Uno",
                    MinParticipants = 2,
                    MaxParticipants = 10,
                    CategoryId = Guid.Parse("c0000000-0000-0000-0000-000000000003")
                },
                new Game
                {
                    Id = Guid.Parse("a0000000-0000-0000-0000-000000000005"),
                    Name = "Pandemic",
                    MinParticipants = 2,
                    MaxParticipants = 4,
                    CategoryId = Guid.Parse("c0000000-0000-0000-0000-000000000004")
                }
            );
        }
    }
}
