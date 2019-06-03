using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Address:BaseEntity
    {
        public int Id {get; set;}
        public String Province {get; set;}
        public String Canton { get; set; }
        public String City { get; set; }
        public String Description { get; set; }

        public Address() { }

    }
}
