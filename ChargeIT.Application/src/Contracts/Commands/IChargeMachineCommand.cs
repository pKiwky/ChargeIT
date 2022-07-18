using ChargeIT.Application.Requests;

namespace ChargeIT.Application.Contracts {

    public interface IChargeMachineCommand {
        Task<int> Create(CreateChargeMachineRequest command);
        Task Delete(int id);
    }

}