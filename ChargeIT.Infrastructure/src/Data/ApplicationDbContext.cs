using ChargeIT.Application.Contracts.Data;
using ChargeIT.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ChargeIT.Infrastructure.Data {

    public class ApplicationDbContext : DbContext, IApplicationDbContext {
        public DbSet<ChargeMachineEntity> ChargeMachines { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken()) {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is TrackableEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries) {
                ((TrackableEntity)entityEntry.Entity).UpdatedDate = DateTime.UtcNow;

                if (entityEntry.State == EntityState.Added) {
                    ((TrackableEntity)entityEntry.Entity).CreatedDate = DateTime.UtcNow;
                }
            }

            foreach (var entityEntry in ChangeTracker.Entries().Where(e => e.Entity is BaseEntity && (e.State == EntityState.Deleted))) {
                entityEntry.State = EntityState.Modified;
                ((BaseEntity)entityEntry.Entity).IsDeleted = true;
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }

}