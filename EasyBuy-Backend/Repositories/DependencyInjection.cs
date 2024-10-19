﻿using EasyBuy_Backend.Repositories.CategoryRepo;
using EasyBuy_Backend.Repositories.InventoryVoucherRepo;
using EasyBuy_Backend.Repositories.UserRepo;
using EasyBuy_Backend.Repositories.ProductRepo;
using EasyBuy_Backend.Repositories.SupplierRepo;
using EasyBuy_Backend.Repositories.VoucherRepo;


namespace EasyBuy_Backend.Repositories
{
    public static class DependencyInjection
    {
        // Đăng ký các lớp repository trong Dependency Injection
        public static void AddRepositories(this IServiceCollection services)
        {
			// Register repositories here
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<ISupplierRepository, SupplierRepository>();
			services.AddScoped<IVoucherRepository, VoucherRepository>();
            services.AddScoped<IInventoryVoucherRepository, InventoryVoucherRepository >();
		}
    }
}
