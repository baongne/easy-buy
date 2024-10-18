﻿using EasyBuy_Backend.Repositories.SupplierRepo;
using EasyBuy_Backend.Repositories.VoucherRepo;
using EasyBuy_Backend.Services.AuthSvc;

namespace EasyBuy_Backend.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            // Register services here
            services.AddHttpClient<IAuthService, AuthService>();

			return services;
        }
    }
}
