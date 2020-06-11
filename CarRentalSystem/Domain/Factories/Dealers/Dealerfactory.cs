﻿using Domain.Models.Dealers;

namespace Domain.Factories.Dealers
{
    public class Dealerfactory: IDealerFactory
    {
        private string dealerName = default!;
        private string dealerPhoneNumber = default!;

        public IDealerFactory WithName(string name)
        {
            this.dealerName = name;
            return this;
        }

        public IDealerFactory WithPhoneNumber(string phoneNumber)
        {
            this.dealerPhoneNumber = phoneNumber;
            return this;
        }

        public Dealer Build() => new Dealer(this.dealerName, this.dealerPhoneNumber);

        public Dealer Build(string name, string phoneNumber)
            => this
                .WithName(name)
                .WithPhoneNumber(phoneNumber)
                .Build();
    }
}
