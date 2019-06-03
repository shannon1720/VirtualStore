using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Cellar : BaseEntity
    {
        public int Id { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public string Id_Store { get; set; }
    }
}
