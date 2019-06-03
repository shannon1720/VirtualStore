using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Preference : BaseEntity
    {
        public int Id { get; set; }
        public int Preference1 { get; set; }
        public int Preference2 { get; set; }
        public int Preference3 { get; set; }
        public bool Active { get; set; }
        public Preference()
        {

        }
    }
}
