using Canteen.Data;
using Canteen.Models;
using Canteen.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Canteen.Repos
{
    public class ContainerRepository : IContainerRepository
    {
        private readonly CanteenContext _context;

        public ContainerRepository(CanteenContext context)
        {
            _context = context;
        }
        public void Add(Container container)
        {
            _context.Add(container);
        }

        public void Delete(Container container)
        {
            _context.Remove(container);
        }

        public async Task<Container> GetByIdAsync(int id)
        {
            return  await _context.Container.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<Container>> ListAllAsync()
        {
            return await _context.Container.ToListAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(Container container)
        {
            _context.Container.Update(container);
        }

    }
}
