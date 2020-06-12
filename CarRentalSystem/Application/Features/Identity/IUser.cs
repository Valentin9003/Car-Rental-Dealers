using Domain.Models.Dealers;

namespace Application.Features.Identity
{
    public interface IUser
    {
        void BecomeDealer(Dealer dealer);
    }
}
