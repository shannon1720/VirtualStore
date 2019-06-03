using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
   public class Currency : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Iso { get; set; }
        public bool Active { get; set; }
    }
}
