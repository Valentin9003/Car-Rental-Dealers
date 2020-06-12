﻿using Application.Features.CarAds;
using Domain.Factories.CarAds;
using Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyTested.AspNetCore.Mvc;

namespace StartUp
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration)
            : base(configuration)
        {
        }

        public void ConfigureTestServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            ValidateServices(services);

            services.ReplaceTransient<UserManager<User>>(_ => IdentityFakes.FakeUserManager);
            services.ReplaceTransient<IJwtTokenGenerator>(_ => JwtTokenGeneratorFakes.FakeJwtTokenGenerator);
        }

        private static void ValidateServices(IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();

            provider.GetRequiredService<ICarAdFactory>();
            provider.GetRequiredService<IMediator>();
            provider.GetRequiredService<ICarAdRepository>();
            provider.GetRequiredService<IControllerFactory>();
        }
    }
}
