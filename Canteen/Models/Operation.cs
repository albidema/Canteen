using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Canteen.Models
{
    public class Operation
    {
        public int Id { get; set; }
        public int SectorId { get; set; }
        public int SourceContainerId { get; set; }
        public double SourceContainerVolume { get; set; }
        public int DestinationContainerId { get; set; }
        public double DestinationContainerVolume { get; set; }
        public double Volume { get; set; }

    }
}
