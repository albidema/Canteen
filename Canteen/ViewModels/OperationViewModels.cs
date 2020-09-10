using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Canteen.ViewModels
{
    public class OperationPostModel
    {
        public int SectorId { get; set; }
        public int SourceContainerId { get; set; }
        public int SourceContainerVolume { get; set; }
        public int DestinationContainerId { get; set; }
        public int DestinationContainerVolume { get; set; }
        public int Volume { get; set; }
    }

    public class OperationPutModel : OperationPostModel
    {
        public int Id { get; set; }
    }

    public class OperationMixModel
    {
        public int SectorId { get; set; }
        public int SourceContainerId { get; set; }
        public int DestinationContainerId { get; set; }
        public double Volume { get; set; }
    }

    public class AddRemoveWineModel
    {
        public int SectorId { get; set; }
        public int ContainerId { get; set; }

        public double Volume { get; set; }
    }
}
