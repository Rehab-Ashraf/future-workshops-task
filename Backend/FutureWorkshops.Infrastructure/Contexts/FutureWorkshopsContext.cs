using Microsoft.EntityFrameworkCore;
using FutureWorkshops.Domain.Entities;
using FutureWorkshops.Infrastructure.Mappings;

namespace FutureWorkshops.Infrastructure.Contexts
{
	public class FutureWorkshopsContext : DbContext
	{
		public FutureWorkshopsContext(DbContextOptions options)
				: base(options)
		{

		}

		public FutureWorkshopsContext()
		{
			
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new WorkItemMap());
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.EnableSensitiveDataLogging(sensitiveDataLoggingEnabled: true);
		}

		public DbSet<WorkItem>  WorkItems { get; set; }
	}
}
