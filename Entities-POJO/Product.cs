using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Product :BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PriceInitial { get; set; }
        public decimal PriceFinal { get; set; }
        public decimal Taxes { get; set; }
        public string Provider { get; set; }
        public int IdCategory { get; set; }
        public int IdCurrency { get; set; }
        public int IdMedia { get; set; }
        public bool State { get; set; }
        public string CategoryName { get; set; }
        public string CurrencyName { get; set; }
        public string Active { get; set; }
        public int Stock { get; set; }

        public Product()
        {

        }
    }

   
}
