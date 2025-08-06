using FutureWorkshops.Domain.Entities;
using FutureWorkshops.Infrastructure.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace FutureWorkshops.Infrastructure.Mappings
{
	public class WorkItemMap : IEntityTypeConfiguration<WorkItem>
	{
		public void Configure(EntityTypeBuilder<WorkItem> builder)
		{
			builder.ToTable($"{typeof(WorkItem).Name}s");

			#region Configure Fields
			builder.Property(prop => prop.Name).HasMaxLength(200);
			builder.HasIndex(prop => prop.Name);
			#endregion

			#region Set Initial Data
			this.Seed(builder);
			#endregion
		}

		private void Seed(EntityTypeBuilder<WorkItem> builder)
		{
			builder.HasData(WorkItemSeed.SeedList);
		}
	}
}
