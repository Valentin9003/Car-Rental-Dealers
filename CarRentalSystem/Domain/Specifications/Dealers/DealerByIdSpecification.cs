using System;
using System.Linq.Expressions;
using Domain.Models.Dealers;

namespace Domain.Specifications.Dealers
{

    public class DealerByIdSpecification : Specification<Dealer>
    {
        private readonly int? id;

        public DealerByIdSpecification(int? id)
            => this.id = id;

        protected override bool Include => this.id != null;

        public override Expression<Func<Dealer, bool>> ToExpression()
            => dealer => dealer.Id == this.id;
    }
}
