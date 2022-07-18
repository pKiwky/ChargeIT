using ChargeIT.Application.Common.Exceptions;
using ChargeIT.Application.Contracts;
using ChargeIT.Application.Contracts.Data;
using ChargeIT.Application.Requests;
using ChargeIT.Domain.Entities;
using Mapster;

namespace ChargeIT.Application.Handlers {

    public class ChargeMachineCommand : IChargeMachineCommand {
        private readonly IApplicationDbContext _applicationDbContext;

        public ChargeMachineCommand(IApplicationDbContext applicationDbContext) {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<int> Create(CreateChargeMachineRequest command) {
            var entity = command.Adapt<ChargeMachineEntity>();

            _applicationDbContext.ChargeMachines.Add(entity);
            await _applicationDbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task Delete(int id) {
            var entity = await _applicationDbContext.ChargeMachines.FindAsync(id);

            if (entity == null) {
                throw new NotFoundException(nameof(ChargeMachineEntity), id);
            }

            _applicationDbContext.ChargeMachines.Remove(entity);
            await _applicationDbContext.SaveChangesAsync();
        }
    }

}