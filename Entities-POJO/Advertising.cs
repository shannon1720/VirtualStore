using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Advertising : BaseEntity
    {
        public int IdProduct { get; set; }
        public string ProductName { get; set; }
        public int IdUserPreferences { get; set; }
        public string Client { get; set; }
        public decimal Price { get; set; }
        public string Email { get; set; }
    }
}
