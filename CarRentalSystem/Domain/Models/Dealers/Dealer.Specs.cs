using Domain.Models.CarAds;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace Domain.Models.Dealers
{
    public class DealerSpecs
    {
        [Fact]
        public void AddCarAdShouldSaveCarAd()
        {
            // Arrange
            var dealer = new Dealer("Valid dealer", "+12345678");
            var carAd = A.Dummy<CarAd>();

            // Act
            dealer.AddCarAd(carAd);

            // Assert
            dealer.CarAds.Should().Contain(carAd);
        }
    }
}
