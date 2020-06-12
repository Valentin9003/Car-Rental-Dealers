﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Application.Contracts;
using Application.Common;

namespace Application.Features.Dealers.Commands.Edit
{
    public class EditDealerCommand : EntityCommand<int>, IRequest<Result>
    {
        public string Name { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;

        public class EditDealerCommandHandler : IRequestHandler<EditDealerCommand, Result>
        {
            private readonly ICurrentUser currentUser;
            private readonly IDealerRepository dealerRepository;

            public EditDealerCommandHandler(
                ICurrentUser currentUser,
                IDealerRepository dealerRepository)
            {
                this.currentUser = currentUser;
                this.dealerRepository = dealerRepository;
            }

            public async Task<Result> Handle(
                EditDealerCommand request, 
                CancellationToken cancellationToken)
            {
                var dealer = await this.dealerRepository.FindByUser(
                    this.currentUser.UserId, 
                    cancellationToken);

                if (request.Id != dealer.Id)
                {
                    return "You cannot edit this dealer.";
                }

                dealer
                    .UpdateName(request.Name)
                    .UpdatePhoneNumber(request.PhoneNumber);

                await this.dealerRepository.Save(dealer, cancellationToken);

                return Result.Success;
            }
        }
    }
}
