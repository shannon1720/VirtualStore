using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class StoreAdministrator : BaseEntity
    {   public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name_1 { get; set; }
        public string Last_Name1 { get; set; }
        public string Last_Name2 { get; set; }
        public string Phone_1 { get; set; }
        public string Id_Store { get; set; }
        public bool Active { get; set; }
        public string State { get; set; }


        public StoreAdministrator() { }

    }
}
