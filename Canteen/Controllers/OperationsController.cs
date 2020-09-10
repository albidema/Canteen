using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Canteen.Data;
using Canteen.Models;
using Canteen.Repos;
using Canteen.ViewModels;

namespace Canteen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationsController : ControllerBase
    {
        private readonly IOperationRepository _repo;

        public OperationsController(IOperationRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Operations
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Operation>>> GetOperation()
        {
            return Ok(await _repo.ListAllAsync());
        }

        // GET: api/Operations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Operation>> GetOperation(int id)
        {
            var operation = await _repo.GetByIdAsync(id);

            if (operation == null)
            {
                return NotFound();
            }

            return operation;
        }

        // PUT: api/Operations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOperation(int id, OperationPutModel operation)
        {
            if (id != operation.Id)
            {
                return BadRequest();
            }

            var model = new Operation
            {
                Id = operation.Id,
                SectorId = operation.SectorId,
                SourceContainerId = operation.SourceContainerId,
                DestinationContainerId = operation.DestinationContainerId,
                DestinationContainerVolume = operation.DestinationContainerVolume,
                Volume = operation.Volume
            };

            _repo.Update(model);

            try
            {
                await _repo.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Operations
        [HttpPost]
        public async Task<ActionResult<Operation>> PostOperation(OperationPostModel operation)
        {
            var model = new Operation
            {
                SectorId = operation.SectorId,
                SourceContainerId = operation.SourceContainerId,
                DestinationContainerId = operation.DestinationContainerId,
                DestinationContainerVolume = operation.DestinationContainerVolume,
                Volume = operation.Volume
            };

            _repo.Add(model);

            await _repo.SaveChangesAsync();

            return Ok(model);
        }

        // DELETE: api/Operations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Operation>> DeleteOperation(int id)
        {
            var operation = await _repo.GetByIdAsync(id);
            if (operation == null)
            {
                return NotFound();
            }

            _repo.Delete(operation);

            await _repo.SaveChangesAsync();

            return operation;
        }

        // Post: api/Operations/MixWine
        [HttpPost("MixWine")]
        public async Task<ActionResult<Operation>> MixWine(OperationMixModel model)
        {
            var operation = await _repo.MixWine(model.SectorId, model.SourceContainerId, model.DestinationContainerId, model.Volume);

            if (operation == null)
                return NotFound();

            return Ok(operation);
        }

        // Post: api/Operations/AddRemoveWine
        [HttpPost("AddRemoveWine")]
        public async Task<ActionResult<Operation>> AddRemoveWine(AddRemoveWineModel model)
        {
            var container = await _repo.AddRemoveWine(model.SectorId, model.ContainerId, model.Volume);

            if (container == null)
                return NotFound();

            return Ok(container);
        }

        private bool OperationExists(int id)
        {
            return _repo.GetByIdAsync(id) != null;
        }
    }
}
