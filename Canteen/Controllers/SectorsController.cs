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
    public class SectorsController : ControllerBase
    {
        private readonly IGenericRepository<Sector> _repo;

        public SectorsController(IGenericRepository<Sector> repo)
        {
            _repo = repo;
        }

        // GET: api/Sectors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sector>>> GetSectors()
        {
            return Ok(await _repo.ListAllAsync());
        }

        // GET: api/Sectors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sector>> GetSector(int id)
        {
            var sector = await _repo.GetByIdAsync(id);

            if (sector == null)
            {
                return NotFound();
            }

            return Ok(sector);
        }

        // PUT: api/Sectors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSector(int id, SectorPutModel sector)
        {
            if (id != sector.Id)
            {
                return BadRequest();
            }

            var model = new Sector { 
                Id = sector.Id,
                Code = sector.Code,
                Description = sector.Description,
                Containers = sector.Containers,
                IsActive = sector.IsActive
            };

            _repo.Update(model);

            try
            {
                await _repo.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SectorExists(id))
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

        // POST: api/Sectors
        [HttpPost]
        public async Task<ActionResult<Sector>> PostSector(SectorPostModel sector)
        {
            var model = new Sector { 
                Code = sector.Code,
                Description = sector.Description,
                Containers = sector.Containers,
                IsActive = sector.IsActive            
            };
            _repo.Add(model);
            await _repo.SaveChangesAsync();

            return Ok(sector);
        }

        // DELETE: api/Sectors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sector>> DeleteSector(int id)
        {
            var sector = await _repo.GetByIdAsync(id);
            if (sector == null)
            {
                return NotFound();
            }

            _repo.Delete(sector);
            await _repo.SaveChangesAsync();

            return Ok(sector);
        }

        private bool SectorExists(int id)
        {
            return _repo.GetByIdAsync(id) != null;
        }
    }
}
