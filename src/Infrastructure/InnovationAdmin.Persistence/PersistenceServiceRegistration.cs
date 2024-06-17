﻿using InnovationAdmin.Application.Contracts.Persistence;

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
            services.AddScoped<IAdminRoleRepository, AdminRoleRepository>();
            services.AddScoped<IAccountManagerRepository, AccountManagerRepository>();
            services.AddScoped<IPharmacyGroupRepository, PharmacyGroupRepository>();
            services.AddScoped<IRemittanceTypeRepository, RemittanceTypeRepository>();
            services.AddScoped<IAdminUserRepository, AdminUserRepository>();
            services.AddScoped<ISysPrefSecurityEmailRepository,  SysPrefSecurityEmailRepository>();
            services.AddScoped<ISysPrefCompanyRepository, SysPrefCompanyRepository>();
            services.AddScoped<ISysPref_GeneralBehaviourRepository, SysPref_GeneralBehaviourRepository>();
            services.AddScoped<ISysPrefFinancialRepository, SysPrefFinancialRepository>();
            services.AddScoped<IReceiptBatchSourceRepository, ReceiptBatchSourceRepository>();
            services.AddScoped<IQuotesRepository, QuotesRepository>();
            services.AddScoped<IDataSourceRepository, DataSourceRepository>();
            services.AddScoped<IBillingMethodTypeRepository, BillingMethodTypeRepository>();
            services.AddScoped<IAPAccountTypeRepository, APAccountTypeRepository>();
            services.AddScoped<ITemplateRepository, TemplateRepository>();
            services.AddScoped<ICorrespondenceNotesRepository, CorrespondenceNotesRepository>();
            services.AddScoped<IDoNotTakeGroup, DoNotTakeGroupRepopsitory>();
            services.AddScoped<IClaimStatusRepository, ClaimStatusRepository>();

            return services;
        }
    }
}
