﻿using System.Threading;
using System.Threading.Tasks;
using Application.Common;
using Application.Contracts;
using Application.Features.Dealers;
using MediatR;

using static Application.Features.CarAds.Commands.Common.ChangeCarAdCommandExtensions;

namespace Application.Features.CarAds.Commands.Delete
{
    public class DeleteCarAdCommand : EntityCommand<int>, IRequest<Result>
    {
        public class DeleteCarAdCommandHandler : IRequestHandler<DeleteCarAdCommand, Result>
        {
            private readonly ICurrentUser currentUser;
            private readonly ICarAdRepository carAdRepository;
            private readonly IDealerRepository dealerRepository;

            public DeleteCarAdCommandHandler(
                ICurrentUser currentUser,
                ICarAdRepository carAdRepository,
                IDealerRepository dealerRepository)
            {
                this.currentUser = currentUser;
                this.carAdRepository = carAdRepository;
                this.dealerRepository = dealerRepository;
            }

            public async Task<Result> Handle(
                DeleteCarAdCommand request,
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

                return await this.carAdRepository.Delete(
                    request.Id,
                    cancellationToken);
            }
        }
    }
}
