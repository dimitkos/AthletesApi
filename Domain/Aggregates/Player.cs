using Domain.Models;

namespace Domain.Aggregates
{
    public class Player : RootEntity<long>
    {
        public string Name { get; }
        public string Phone { get; private set; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; private set; }
        public int Trophies { get; private set; }

        public Player(long id, string name, string phone, DateTime createdAt, DateTime updatedAt, int trophies) : base(id)
        {
            Name = name;
            Phone = phone;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Trophies = trophies;
        }

#warning use interface instead static
        public static AddPlayerDomainModel AddPlayer(string name, string phone)
        {
            var now = DateTime.UtcNow;
#warning use idgenerator
            var player = new Player(
                id: 1,
                name: name,
                phone: phone,
                createdAt: now,
                updatedAt: now,
                trophies: 0);

            return new AddPlayerDomainModel(player);
        }

        public UpdatePhoneDomainModel UpdatePhone(string phoneNumber)
        {
            UpdatedAt = DateTime.UtcNow;
            Phone = phoneNumber;

            return new UpdatePhoneDomainModel(this);
        }

        public WinTrophyDomainModel WinTrophy()
        {
            UpdatedAt = DateTime.UtcNow;
            Trophies++;

            return new WinTrophyDomainModel(this);
        }
    }
}
