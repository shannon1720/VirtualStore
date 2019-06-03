using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Shipping : BaseEntity
    {

        public int Id {get; set;}
        public String Identification {get; set;}
        public String Name {get; set;}
        public String Logo{get; set;}
        public decimal CoveredArea {get; set;}
        public String Phone_Number {get; set;}
        public decimal Minimum_Rate { get; set;}
        public decimal Rate { get; set;}
        public Boolean Active { get; set; }
        public String Email { get; set;}
        public int IdCurrency { get; set; }
        public string CurrencyName { get; set; }
        public String State { get; set;}
        public Shipping() {}
    }
}
