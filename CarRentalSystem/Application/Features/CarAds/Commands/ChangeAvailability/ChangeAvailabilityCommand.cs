﻿using System.Threading;
using System.Threading.Tasks;
using Application.Common;
using Application.Contracts;
using Application.Features.Dealers;
using MediatR;

using static Application.Features.CarAds.Commands.Common.ChangeCarAdCommandExtensions;

namespace Application.Features.CarAds.Commands.ChangeAvailability
{
    public class ChangeAvailabilityCommand : EntityCommand<int>, IRequest<Result>
    {
        public class ChangeAvailabilityCommandHandler : IRequestHandler<ChangeAvailabilityCommand, Result>
        {
            private readonly ICurrentUser currentUser;
            private readonly ICarAdRepository carAdRepository;
            private readonly IDealerRepository dealerRepository;

            public ChangeAvailabilityCommandHandler(
                ICurrentUser currentUser,
                ICarAdRepository carAdRepository,
                IDealerRepository dealerRepository)
            {
                this.currentUser = currentUser;
                this.carAdRepository = carAdRepository;
                this.dealerRepository = dealerRepository;
            }

            public async Task<Result> Handle(
                ChangeAvailabilityCommand request, 
                CancellationToken cancellationToken)
            {
                var dealerHasCar = await this.currentUser.DealerHasCarAd(
                    this.dealerRepository,
                    request.Id,
                    cancellationToken);

                if (!dealerHasCar)
                {
                    return dealerHasCar;
                }

                var carAd = await this.carAdRepository
                    .Find(request.Id, cancellationToken);

                carAd.ChangeAvailability();

                await this.carAdRepository.Save(carAd, cancellationToken);

                return Result.Success;
            }
        }
    }
}
