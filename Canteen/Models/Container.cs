using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Canteen.Models
{
    public class Container
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public double Volume { get; set; }

        public int SectorId { get; set; }

        public virtual Sector Sector { get; set; }
    }
}
