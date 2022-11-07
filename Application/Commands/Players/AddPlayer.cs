using MediatR;

namespace Application.Commands.Players
{
    public class AddPlayer : IRequest<Unit>
    {
        public string Name { get; }
        public string PhoneNumber { get; }

        public AddPlayer(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }
    }
}
