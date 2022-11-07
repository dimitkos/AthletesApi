using Domain.Aggregates;

namespace Domain.Models
{
    public class AddPlayerDomainModel
    {
        public Player Player { get; }

        public AddPlayerDomainModel(Player player)
        {
            Player = player;
        }
    }

    public class UpdatePhoneDomainModel
    {
        public Player Player { get; }

        public UpdatePhoneDomainModel(Player player)
        {
            Player = player;
        }
    }

    public class WinTrophyDomainModel
    {
        public Player Player { get; }

        public WinTrophyDomainModel(Player player)
        {
            Player = player;
        }
    }
}
