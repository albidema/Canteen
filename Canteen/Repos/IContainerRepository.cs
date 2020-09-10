using Canteen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Canteen.Repos
{
    public interface IContainerRepository
    {
        Task<Container> GetByIdAsync(int id);
        Task<IReadOnlyList<Container>> ListAllAsync();
        void Add(Container container);
        void Update(Container container);
        void Delete(Container container);
        Task<int> SaveChangesAsync();
    }
}
