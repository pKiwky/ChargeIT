using ChargeIT.Application.Common.Exceptions;
using ChargeIT.Application.Contracts;
using ChargeIT.Application.Contracts.Data;
using ChargeIT.Application.Requests;
using ChargeIT.Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.JsonPatch;

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

        public async Task<bool> Update(int id, UpdateChargeMachineRequest command) {
            var entity = await _applicationDbContext.ChargeMachines.FindAsync(id);

            if (entity == null) {
                throw new NotFoundException(nameof(ChargeMachineEntity), id);
            }

            entity.Number = command.Number;
            entity.Longitude = command.Longitude;
            entity.Latitude = command.Latitude;
            entity.City = command.City;
            entity.Street = command.Street;
            
            _applicationDbContext.ChargeMachines.Update(entity);
            return await _applicationDbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdatePatch(int id, JsonPatchDocument command) {
            return true;
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