using Domain.Factories.CarAds;
using Domain.Factories.Dealers;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Domain
{
   public class DomainConfigurationSpecs
    {
        [Fact]
        public void AddDomainShouldRegisterFactories()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();

            // Act
            var services = serviceCollection
                .AddDomain()
                .BuildServiceProvider();

            // Assert
            services
                .GetService<IDealerFactory>()
                .Should()
                .NotBeNull();

            services
                .GetService<ICarAdFactory>()
                .Should()
                .NotBeNull();
        }
    }
}
