using ChargeIT.Application.Contracts;
using ChargeIT.Application.Requests;
using ChargeIT.Domain.DTO;
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

        [HttpGet("{id}")]
        public async Task<ChargeMachineDTO> Get(int id) {
            return await _chargeMachineQuery.GetById(id);
        }

        [HttpGet("{page}/{size}")]
        public async Task<IEnumerable<ChargeMachineDTO>> Get(int page, int size) {
            return await _chargeMachineQuery.GetPaginated(page, size);
        }

        [HttpPost]
        public async Task<int> Post(CreateChargeMachineRequest command) {
            return await _chargeMachineCommand.Create(command);
        }

        [HttpPut("{id}")]
        public async Task<bool> Put(int id, UpdateChargeMachineRequest command) {
            return await _chargeMachineCommand.Update(id, command);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) {
            await _chargeMachineCommand.Delete(id);
            return Ok();
        }
    }

}