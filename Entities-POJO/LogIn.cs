using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class LogIn : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int Rol { get; set; }
        public Boolean State { get; set; }

        public LogIn()
        {

        }
    }
}
