using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Canteen.ViewModels
{
    public class ContainerPostModel
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Volume { get; set; }
        public int SectorId { get; set; }
    }

    public class ContainerPutModel : ContainerPostModel 
    {
        public int Id { get; set; }
    }
}
