using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Canteen.Models
{
    public class Sector
    {
        public Sector()
        {
            this.Containers = new HashSet<Container>();
        }
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Container> Containers { get; set; }
    }
}
