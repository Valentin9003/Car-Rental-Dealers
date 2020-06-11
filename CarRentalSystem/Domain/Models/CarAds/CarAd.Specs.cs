using Domain.Models.CarAds;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace Domain.Models.CarAds
{
    public class CarAdSpecs
    {
        [Fact]
        public void ChangeAvailabilityShouldMutateIsAvailable()
        {
            // Arrange
            var carAd = A.Dummy<CarAd>();

            // Act
            carAd.ChangeAvailability();

            // Assert
            carAd.IsAvailable.Should().BeFalse();
        }
    }
}
