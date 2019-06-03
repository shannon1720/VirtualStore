using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Inventory : BaseEntity
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public int IdCellar { get; set; }
        public int Stock { get; set; }
        public bool Active { get; set; }

        public string NameProduct { get; set; }
    }
}
