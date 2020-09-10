using Canteen.Data;
using Canteen.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Canteen.Repos
{
    public class OperationRepository : IOperationRepository
    {
        private readonly CanteenContext _context;

        public OperationRepository(CanteenContext context)
        {
            _context = context;
        }
        public void Add(Operation operation)
        {
            _context.Operation.Add(operation);
        }

        public async Task<Container> AddRemoveWine(int sectorId, int containerId, double volume)
        {
            var container = await _context.Container.FirstOrDefaultAsync(x => x.Code == containerId && x.SectorId == sectorId);

            container.Volume = container.Volume + volume;

            _context.Container.Update(container);
            await this.SaveChangesAsync();

            return container;
        }

        public void Delete(Operation operation)
        {
            _context.Operation.Remove(operation);
        }

        public async Task<Operation> GetByIdAsync(int id)
        {
            return await _context.Operation.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<Operation>> ListAllAsync()
        {
            return await _context.Operation.ToListAsync();
        }

        public async Task<Operation> MixWine(int sectorId, int sourceContainerId, int destinationContainerId, double volume)
        {
            var sourceContainer = _context.Container.FirstOrDefault(x => x.Code == sourceContainerId && x.SectorId == sectorId);

            var destinationContainer = _context.Container.FirstOrDefault(x => x.Code == destinationContainerId && x.SectorId == sectorId);

            sourceContainer.Volume = sourceContainer.Volume - volume;
            
            destinationContainer.Volume = destinationContainer.Volume + volume;

            _context.Update(sourceContainer);
            _context.Update(destinationContainer);

            var operation = new Operation { 
                SectorId = sectorId,
                SourceContainerId = sourceContainerId,
                SourceContainerVolume = sourceContainer.Volume,
                DestinationContainerId = destinationContainerId,
                DestinationContainerVolume = destinationContainer.Volume,
                Volume = volume
            };

            _context.Operation.Add(operation);

            await this.SaveChangesAsync();

            return operation;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(Operation operation)
        {
            _context.Operation.Update(operation);
        }
    }
}
