using Application.Features.CarAds.Commands.Common;
using FluentValidation;

namespace Application.Features.CarAds.Commands.Create
{
    public class CreateCarAdCommandValidator : AbstractValidator<CreateCarAdCommand>
    {
        public CreateCarAdCommandValidator(ICarAdRepository carAdRepository) 
            => this.Include(new CarAdCommandValidator<CreateCarAdCommand>(carAdRepository));
    }
}
