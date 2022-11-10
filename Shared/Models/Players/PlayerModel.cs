namespace Shared.Models.Players
{
    public class PlayerModel
    {
        public long Id { get; }
        public string Name { get; }
        public string Phone { get; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }
        public int Trophies { get; }

        public PlayerModel(long id, string name, string phone, DateTime createdAt, DateTime updatedAt, int trophies)
        {
            Id = id;
            Name = name;
            Phone = phone;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Trophies = trophies;
        }
    }
}
