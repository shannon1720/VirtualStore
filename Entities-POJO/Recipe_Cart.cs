using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Recipe_Cart:BaseEntity
    {

        public int Id { get; set; }
        public int Id_Cart { get; set; }
        public int Id_Recipe { get; set; }

        public Recipe_Cart() {



        }
    }
}
