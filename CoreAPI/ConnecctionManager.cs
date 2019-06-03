using DataAcess.Dao;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
  public class ConnecctionManager:BaseManager
    {

        protected SqlDao dao;
        Boolean ifConnect;
        public ConnecctionManager()
        {
            dao = SqlDao.GetInstance();
            ifConnect= dao.VerifyConnection();
        }

        public void validate()
        {
            try
            {
                if (!ifConnect)
                {
                    throw new BussinessException(1);

                }
            }
            catch(Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        
        }






    }
}
