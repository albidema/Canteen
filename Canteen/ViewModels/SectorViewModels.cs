using Canteen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Canteen.ViewModels
{
    public class SectorPostModel
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Container> Containers { get; set; }
    }

    public class SectorPutModel : SectorPostModel
    {
        public int Id { get; set; }
    }
}
