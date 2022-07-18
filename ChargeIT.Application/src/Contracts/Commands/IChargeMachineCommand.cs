using ChargeIT.Application.Requests;
using Microsoft.AspNetCore.JsonPatch;

namespace ChargeIT.Application.Contracts {

    public interface IChargeMachineCommand {
        Task<int> Create(CreateChargeMachineRequest command);
        Task<bool> Update(int id, UpdateChargeMachineRequest command);
        Task<bool> UpdatePatch(int id, JsonPatchDocument command);
        Task Delete(int id);
    }

}