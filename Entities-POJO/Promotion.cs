using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    class Promotion : BaseEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int IdProduct { get; set; }
        public int IdTypePromotion { get; set; }
        public decimal Amount { get; set; }
        public DateTime Starts { get; set; }
        public DateTime Ends { get; set; }
    }
}
