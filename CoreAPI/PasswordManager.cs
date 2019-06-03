using DataAcess.Crud;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class PasswordManager : BaseManager
    {
        private PasswordCrudFactory crudPassword;

        public PasswordManager()
        {
            crudPassword = new PasswordCrudFactory();
        }

        public void Update(Password pass)
        {
            crudPassword.Update(pass);
        }


        public Password RetrieveById(Password pass)
        {
            Password  s = null;
            try
            {
                s = crudPassword.Retrieve<Password>(pass);
                if (s == null)
                {
                    throw new BussinessException(4);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return s;
        }
    }
}
