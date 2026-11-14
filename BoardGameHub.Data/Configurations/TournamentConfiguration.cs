using BoardGameHub.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardGameHub.Data.Configurations
{
    public class TournamentConfiguration : IEntityTypeConfiguration<Tournament>
    {
        public void Configure(EntityTypeBuilder<Tournament> builder)
        {
            builder.HasData(
                new Tournament
                {
                    Id = Guid.Parse("d0000000-0000-0000-0000-000000000001"),
                    Title = "Catan Winter Cup",
                    StartDateAndTime = new DateTime(2026, 12, 12, 18, 0, 0),
                    MaxParticipants = 16,
                    Description = "Friendly Catan tournament with prizes for the top three players.",
                    Status = true,
                    ShopId = Guid.Parse("b0000000-0000-0000-0000-000000000001"),
                    GameId = Guid.Parse("a0000000-0000-0000-0000-000000000001")
                },
                new Tournament
                {
                    Id = Guid.Parse("d0000000-0000-0000-0000-000000000002"),
                    Title = "Carcassonne Open",
                    StartDateAndTime = new DateTime(2026, 12, 19, 17, 0, 0),
                    MaxParticipants = 20,
                    Description = "Open Carcassonne tournament for all skill levels.",
                    Status = true,
                    ShopId = Guid.Parse("b0000000-0000-0000-0000-000000000002"),
                    GameId = Guid.Parse("a0000000-0000-0000-0000-000000000002")
                },
                new Tournament
                {
                    Id = Guid.Parse("d0000000-0000-0000-0000-000000000003"),
                    Title = "Codenames Night",
                    StartDateAndTime = new DateTime(2027, 01, 09, 19, 0, 0),
                    MaxParticipants = 24,
                    Description = "Team-based Codenames evening, come with friends or find a team.",
                    Status = true,
                    ShopId = Guid.Parse("b0000000-0000-0000-0000-000000000002"),
                    GameId = Guid.Parse("a0000000-0000-0000-0000-000000000003")
                },
                new Tournament
                {
                    Id = Guid.Parse("d0000000-0000-0000-0000-000000000004"),
                    Title = "Pandemic Co-op Challenge",
                    StartDateAndTime = new DateTime(2027, 01, 23, 16, 0, 0),
                    MaxParticipants = 12,
                    Description = "Cooperative challenge, teams compete for the fastest cure.",
                    Status = false,
                    ShopId = Guid.Parse("b0000000-0000-0000-0000-000000000001"),
                    GameId = Guid.Parse("a0000000-0000-0000-0000-000000000005")
                }
            );
        }
    }
}

