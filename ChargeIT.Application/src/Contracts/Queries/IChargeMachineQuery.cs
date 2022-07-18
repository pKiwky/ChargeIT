using ChargeIT.Domain.DTO;

namespace ChargeIT.Application.Contracts {

    public interface IChargeMachineQuery {
        Task<ChargeMachineDTO> GetById(int id);
        Task<IEnumerable<ChargeMachineDTO>> GetPaginated(int page, int size);
    }

}