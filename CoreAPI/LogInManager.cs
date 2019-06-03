using DataAcess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class LogInManager : BaseManager
    {

        private LogInCrudFactory crudLogIn;

        public LogInManager()
        {
            crudLogIn = new LogInCrudFactory();
        }

        public List<LogIn> RetrieveAll()
        {
            return crudLogIn.RetrieveAll<LogIn>();
        }

        public LogIn initiate(LogIn data)
        {
            List<LogIn> listRecords = RetrieveAll();
            LogIn obj = new LogIn();


            foreach(LogIn record in listRecords)
            {
                if(record.Email.Equals(data.Email) && record.Password.Equals(data.Password))
                {
                    obj.Email = data.Email;
                    obj.Password = data.Password;
                    obj.Rol = record.Rol;
                    obj.State = record.State;
                }
            }

            return obj;
        }
    }
}
