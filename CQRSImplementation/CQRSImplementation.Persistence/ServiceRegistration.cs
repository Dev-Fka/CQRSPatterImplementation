using CQRSImplementation.Application.Interfaces.IRepository;
using CQRSImplementation.Persistence.Context;
using CQRSImplementation.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSImplementation.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(
               opt => opt.UseSqlServer(
                   configuration["connectionString"]
                   )
               );
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddTransient(typeof(GenericRepository<>));
        }

    }
}
