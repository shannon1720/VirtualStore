using System;
namespace Entities_POJO
{
    public class Store : BaseEntity
    {
        public string Id{ get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int Category { get; set; }

        public decimal Earnings = 0;
        public bool Active { get; set; }
        public int IdCellar { get; set; }
        public string State { get; set; }

        public Store() {
        }
    }
}