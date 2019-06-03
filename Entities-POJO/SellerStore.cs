using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class SellerStore : BaseEntity
    {
        public string Email { get; set; }
        public string ID { get; set; }
        public string Url_Photo_ID { get; set; }
        public string Name_1 { get; set; }
        public string Name_2 { get; set; }
        public string Last_Name_1 { get; set; }
        public string Last_Name_2 { get; set; }
        public string Phone_1 { get; set; }
        public string Phone_2 { get; set; }
        public int ID_Address { get; set; }
        public string Url_Profile_Pric { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public string ID_Store{ get; set; }
        public int ID_Rol { get; set; }
        public string State { get; set; }

        public SellerStore()
        {

        }

    }
}
