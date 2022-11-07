using MediatR;

namespace Application.Commands.Players
{
    class UpdatePhoneHandler : IRequestHandler<UpdatePhone, Unit>
    {
        public Task<Unit> Handle(UpdatePhone request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
