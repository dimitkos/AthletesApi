using MediatR;

namespace Application.Commands.Players
{
    public class UpdatePhone : IRequest<Unit>
    {
        public long PlayerId { get; set; }
        public string PhoneNumber { get; }

        public UpdatePhone(long playerId, string phoneNumber)
        {
            PlayerId = playerId;
            PhoneNumber = phoneNumber;
        }
    }
}
