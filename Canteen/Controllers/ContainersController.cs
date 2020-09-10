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
    public class ContainersController : ControllerBase
    {
        private readonly IContainerRepository _repo;

        public ContainersController(IContainerRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Containers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Container>>> GetContainers()
        {
            return Ok(await _repo.ListAllAsync());
        }

        // GET: api/Containers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Container>> GetContainer(int id)
        {
            var container = await _repo.GetByIdAsync(id);

            if (container == null)
            {
                return NotFound();
            }

            return Ok(container);
        }

        // PUT: api/Containers/5    
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContainer(int id, ContainerPutModel container)
        {
            if (id != container.Id)
            {
                return BadRequest();
            }

            var model = new Container
            {
                Id = container.Id,
                Code = container.Code,
                Description = container.Description,
                SectorId = container.SectorId,
                Type = container.Type,
                Volume = container.Volume
            };

            _repo.Update(model);

            try
            {
                await _repo.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContainerExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Container>> PostContainer(ContainerPostModel container)
        {
            var model = new Container
            {
                Code = container.Code,
                Description = container.Description,
                SectorId = container.SectorId,
                Type = container.Type,
                Volume = container.Volume
            };

            _repo.Add(model);
            await _repo.SaveChangesAsync();

            return Ok(container);
        }

        // DELETE: api/Containers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Container>> DeleteContainer(int id)
        {
            var container = await _repo.GetByIdAsync(id);
            if (container == null)
            {
                return NotFound();
            }

            if (container.Volume > 0)
                return BadRequest("Container should be empty");

            _repo.Delete(container);
            await _repo.SaveChangesAsync();

            return container;
        }

        private bool ContainerExists(int id)
        {
            return _repo.GetByIdAsync(id) != null;
        }
    }
}
