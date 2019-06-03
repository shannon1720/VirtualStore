using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
   public  class CartStore : BaseEntity
    {
        public int Id {get; set;}
        public string Email {get; set; }
        public int IdProduct{get; set;}
        public int Quantity {get; set;}
        public Boolean Active {get; set;}

        public CartStore() {


        }

    }
}
