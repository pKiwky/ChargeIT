using ChargeIT.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChargeIT.Application.Contracts.Data {

    public interface IApplicationDbContext {
        public DbSet<ChargeMachineEntity> ChargeMachines { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }

}