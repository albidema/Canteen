using Canteen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Canteen.Repos
{
    public interface IOperationRepository
    {
        Task<Operation> GetByIdAsync(int id);
        Task<IReadOnlyList<Operation>> ListAllAsync();
        void Add(Operation operation);
        void Update(Operation operation);
        void Delete(Operation operation);
        Task<int> SaveChangesAsync();
        Task<Container> AddRemoveWine(int sectorId, int containerId, double volume);
        Task<Operation> MixWine(int sectorId, int sourceContainerId, int destinationContainerId, double volume);
    }
}
