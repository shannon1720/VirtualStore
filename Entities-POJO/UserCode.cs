using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class UserCode : BaseEntity
    {
        public string Email { get; set; }
        public string Code { get; set; }

        public UserCode()
        {

        }
    }
}
