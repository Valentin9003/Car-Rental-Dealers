using Domain.Common;
using Domain.Factories;
using Microsoft.Extensions.DependencyInjection;
using Domain.Models.CarAds;

namespace Domain
{
    public static class DomainConfiguration
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
           => services
               .Scan(scan => scan
                   .FromCallingAssembly()
                   .AddClasses(classes => classes
                       .AssignableTo(typeof(IFactory<>)))
                   .AsMatchingInterface()
                   .WithTransientLifetime())
               .AddTransient<IInitialData, CategoryData>();
    }
}
