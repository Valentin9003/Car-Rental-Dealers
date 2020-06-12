using System;
using System.Reflection;
using Application.Features.CarAds;
using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Persistence;
using Xunit;

namespace Infrastructure
{
    public class InfrastructureConfigurationSpecs
    {
        [Fact]
        public void AddRepositoriesShouldRegisterRepositories()
        {
            // Arrange
            var serviceCollection = new ServiceCollection()
                .AddDbContext<CarRentalDbContext>(opts => opts
                    .UseInMemoryDatabase(Guid.NewGuid().ToString()));

            // Act
            var services = serviceCollection
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddRepositories()
                .BuildServiceProvider();

            // Assert
            services
                .GetService<ICarAdRepository>()
                .Should()
                .NotBeNull();
        }
    }
}
