using Application.Features.CarAds.Commands.Common;
using FluentValidation;

namespace Application.Features.CarAds.Commands.Edit
{
    public class EditCarAdCommandValidator : AbstractValidator<EditCarAdCommand>
    {
        public EditCarAdCommandValidator(ICarAdRepository carAdRepository)
            => this.Include(new CarAdCommandValidator<EditCarAdCommand>(carAdRepository));
    }
}
