using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class BussinesManager : BaseEntity
    {

        public String Id { get; set; }
        public String Name_1 { get; set; }
        public String Name_2 { get; set; }
        public String LastName_1 { get; set; }
        public String LastName_2 { get; set; }
        public String Phone_1 { get; set; }
        public String Phone_2 { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String URL_Profile_Pric { get; set; }
        public String URL_Photo_ID { get; set; }
        public int ID_Rol { get; set; }
        public int Id_Address { get; set; }
        public String Id_shipping { get; set; }
        public String Name{get; set;}
        public Boolean State {get; set;}
        public String Active { get; set; }
        public BussinesManager(){

           
        }


    }
}
