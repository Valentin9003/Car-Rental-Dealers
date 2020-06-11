using Domain.Exceptions;
using Domain.Models.CarAds;
using FluentAssertions;
using System;
using Xunit;

namespace Domain.Factories.CarAds
{
    public class CarAdFactorySpecs
    {
        [Fact]
        public void BuildShouldThrowExceptionIfManufacturerIsNotSet()
        {
            // Assert
            var carAdFactory = new CarAdFactory();

            // Act
            Action act = () => carAdFactory
                .WithCategory("TestCategory", "TestDescription")
                .WithOptions(true, 2, TransmissionType.Automatic)
                .Build();

            // Assert
            act.Should().Throw<InvalidCarAdException>();
        }

        [Fact]
        public void BuildShouldThrowExceptionIfCategoryIsNotSet()
        {
            // Assert
            var carAdFactory = new CarAdFactory();

            // Act
            Action act = () => carAdFactory
                .WithManufacturer("TestManufacturer")
                .WithOptions(true, 2, TransmissionType.Automatic)
                .Build();

            // Assert
            act.Should().Throw<InvalidCarAdException>();
        }

        [Fact]
        public void BuildShouldThrowExceptionIfOptionsAreNotSet()
        {
            // Assert
            var carAdFactory = new CarAdFactory();

            // Act
            Action act = () => carAdFactory
                .WithManufacturer("TestManufacturer")
                .WithCategory("TestCategory", "TestDescription")
                .Build();

            // Assert
            act.Should().Throw<InvalidCarAdException>();
        }

        [Fact]
        public void BuildShouldCreateCarAdIfEveryPropertyIsSet()
        {
            // Assert
            var carAdFactory = new CarAdFactory();

            // Act
            var carAd = carAdFactory
                .WithManufacturer("TestManufacturer")
                .WithCategory(CategoryFakes.ValidCategoryName, "TestCategoryDescription")
                .WithOptions(true, 2, TransmissionType.Automatic)
                .WithImageUrl("http://test.image.url")
                .WithModel("TestModel")
                .WithPricePerDay(10)
                .Build();

            // Assert
            carAd.Should().NotBeNull();
        }
    }
}
