using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Recipe : BaseEntity
    {
        public int Id {get; set;}
        public String Email {get; set;}
        public int IdProvider { get; set; }
        public decimal TotalProvider { get; set; }
        public decimal Total { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }

        public Recipe() { }


    }
}
