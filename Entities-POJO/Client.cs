using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{

    public class Client : BaseEntity
    {
        public string Email { get; set; }
        public string Id { get; set; }
        public string Url_Photo_Id { get; set; }
        public int Id_Rol { get; set; }
        public string Name_1{ get; set; }
        public string Name_2 { get; set; }
        public string Last_Name_1 { get; set; }
        public string Last_Name_2 { get; set; }
        public string Phone_1 { get; set; }
        public string Phone_2{ get; set; }
        public int Id_Address { get; set; }
        public string Url_Profile_Pric { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public string State { get; set; }

        public Client()
        {

        }

    }

}
   