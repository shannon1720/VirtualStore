using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Category : BaseEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public string State { get; set; }

        public Category()
        {

        }
    }
}
