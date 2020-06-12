﻿using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using Application.Features.CarAds.Commands.Common;
using Application.Features.Dealers;
using Domain.Common;
using Domain.Factories.CarAds;
using Domain.Models.CarAds;
using MediatR;

namespace Application.Features.CarAds.Commands.Create
{
    public class CreateCarAdCommand : CarAdCommand<CreateCarAdCommand>, IRequest<CreateCarAdOutputModel>
    {
        public class CreateCarAdCommandHandler : IRequestHandler<CreateCarAdCommand, CreateCarAdOutputModel>
        {
            private readonly ICurrentUser currentUser;
            private readonly IDealerRepository dealerRepository;
            private readonly ICarAdRepository carAdRepository;
            private readonly ICarAdFactory carAdFactory;

            public CreateCarAdCommandHandler(
                ICurrentUser currentUser, 
                IDealerRepository dealerRepository, 
                ICarAdRepository carAdRepository, 
                ICarAdFactory carAdFactory)
            {
                this.currentUser = currentUser;
                this.dealerRepository = dealerRepository;
                this.carAdRepository = carAdRepository;
                this.carAdFactory = carAdFactory;
            }

            public async Task<CreateCarAdOutputModel> Handle(
                CreateCarAdCommand request, 
                CancellationToken cancellationToken)
            {
                var dealer = await this.dealerRepository.FindByUser(
                    this.currentUser.UserId, 
                    cancellationToken);

                var category = await this.carAdRepository.GetCategory(
                    request.Category, 
                    cancellationToken);

                var manufacturer = await this.carAdRepository.GetManufacturer(
                    request.Manufacturer, 
                    cancellationToken);

                var factory = manufacturer == null
                    ? this.carAdFactory.WithManufacturer(request.Manufacturer)
                    : this.carAdFactory.WithManufacturer(manufacturer);

                var carAd = factory
                    .WithModel(request.Model)
                    .WithCategory(category)
                    .WithImageUrl(request.ImageUrl)
                    .WithPricePerDay(request.PricePerDay)
                    .WithOptions(
                        request.HasClimateControl,
                        request.NumberOfSeats,
                        Enumeration.FromValue<TransmissionType>(request.TransmissionType))
                    .Build();

                dealer.AddCarAd(carAd);

                await this.carAdRepository.Save(carAd, cancellationToken);

                return new CreateCarAdOutputModel(carAd.Id);
            }
        }
    }
}
