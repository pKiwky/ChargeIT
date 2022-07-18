using ChargeIT.Application.Contracts;
using ChargeIT.Application.Requests;
using ChargeIT.WebAPI.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace ChargeIT.WebAPI.Controllers {

    public class ChargeMachineController : ApiController {
        private readonly IChargeMachineCommand _chargeMachineCommand;
        private readonly IChargeMachineQuery _chargeMachineQuery;

        public ChargeMachineController(IChargeMachineCommand chargeMachineCommand, IChargeMachineQuery chargeMachineQuery) {
            _chargeMachineCommand = chargeMachineCommand;
            _chargeMachineQuery = chargeMachineQuery;
        }

        [HttpPost]
        public async Task<int> Post(CreateChargeMachineRequest command) {
            return await _chargeMachineCommand.Create(command);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id) {
            await _chargeMachineCommand.Delete(id);
            return Ok();
        }
    }

}