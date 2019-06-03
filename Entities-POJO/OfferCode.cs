using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class OfferCode : BaseEntity
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public int Product { get; set; }
        public int Provider { get; set; }
        public bool Active { get; set; }
    }
}
