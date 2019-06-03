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
    public class UserCodeManager : BaseManager
    {
        private UserCodeCrudFactory crudCode;

        public UserCodeManager()
        {
            crudCode = new UserCodeCrudFactory();
        }

        public void ValidateCode(UserCode code)
        {
            if(code.Code == "P@as123s")
            {
                crudCode.Delete(code);
            }
            else
            {
                throw new BussinessException(3);

            }
        }
    }
}
