using ChargeIT.Application.Common.Exceptions;
using ChargeIT.Application.Contracts;
using ChargeIT.Application.Contracts.Data;
using ChargeIT.Domain.DTO;
using ChargeIT.Domain.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace ChargeIT.Application.Handlers {

    public class ChargeMachineQuery : IChargeMachineQuery {
        private readonly IApplicationDbContext _applicationDbContext;

        public ChargeMachineQuery(IApplicationDbContext applicationDbContext) {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<ChargeMachineDTO> GetById(int id) {
            var entity = await _applicationDbContext.ChargeMachines.FindAsync(id);

            if (entity == null) {
                throw new NotFoundException(nameof(ChargeMachineEntity), id);
            }

            return entity.Adapt<ChargeMachineDTO>();
        }

        public async Task<IEnumerable<ChargeMachineDTO>> GetPaginated(int page, int size) {
            return await _applicationDbContext.ChargeMachines
                .OrderBy(cm => cm.Id)
                .Skip(page)
                .Take(size)
                .ProjectToType<ChargeMachineDTO>()
                .ToListAsync();
        }
    }

}