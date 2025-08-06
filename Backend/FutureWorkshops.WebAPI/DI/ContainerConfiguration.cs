
using FutureWorkshops.Business;
using FutureWorkshops.Business.IRepositories;
using FutureWorkshops.Business.IServices;
using FutureWorkshops.Business.Services;
using FutureWorkshops.Infrastructure.Contexts;
using FutureWorkshops.Infrastructure.Repositories;
using FutureWorkshops.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace FutureWorkshops.WebAPI.DI
{

    public class ContainerConfiguration
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMemoryCache();

			#region Register AutoMapper
			services.AddAutoMapper(typeof(Profile).Assembly);
			#endregion

			services.AddHttpContextAccessor();
			services.AddScoped<ILoggerService, LoggerService>();

			#region Add Db Context
			services.AddDbContext<FutureWorkshopsContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionString:FutureWorkshopsConnection"], b => b.MigrationsAssembly("FutureWorkshops.Infrastructure"));
            });
            #endregion

            #region Register MarketCoreContext
            services.AddScoped<FutureWorkshopsContext, FutureWorkshopsContext>();
			#endregion

			#region Register Repositories
			services.AddScoped<IWorkItemRepositoryAsync, WorkItemRepositoryAsync>();
			services.AddScoped<IUnitOfWorkAsync, UnitOfWorkAsync>();

			#endregion

			#region Register Services
			services.AddScoped<IWorkItemService, WorkItemService>();
			#endregion
		}
	}
}
