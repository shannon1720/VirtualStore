using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Email : BaseEntity
    {
        public string Mail { get; set; }
        public string Name_1 { get; set; }
        public string Last_Name_1{ get; set; }
        public string Code { get; set; }

        public Email()
        {

        }
    }
}
