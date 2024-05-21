using InnovationAdmin.Application.Contracts.Persistence;
using InnovationAdmin.Infrastructure.EncryptDecrypt;
using InnovationAdmin.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InnovationAdmin.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ApplicationConnectionString")));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IAdminUserRepository, AdminUserRepository>();

            return services;
        }
    }
}
