using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Password : BaseEntity
    {
        public string Email { get; set; }
        public string UserPassword { get; set; }
        public string CurrentPassword { get; set;}

        public Password()
        {

        }

    }
}
