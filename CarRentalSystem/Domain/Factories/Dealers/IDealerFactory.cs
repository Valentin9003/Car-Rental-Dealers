
using Domain.Models.Dealers;

namespace Domain.Factories.Dealers
{
    public interface IDealerFactory: IFactory<Dealer>
    {
        IDealerFactory WithName(string name);

        IDealerFactory WithPhoneNumber(string phoneNumber);
    }
}
