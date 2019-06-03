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
    public class BussinesManageManager:BaseManager
    {

        private CrudFactoryAddress crudAddress;
        private CrudFactoryBussinesManager crudBussines;

        public BussinesManageManager()
        {
            crudBussines = new CrudFactoryBussinesManager();
            crudAddress = new CrudFactoryAddress();
        }

        public void Create(BussinesManager bussines)
        {
            try
            {
                Address a = crudAddress.Retrieve<Address>(bussines);
                bussines.Id_Address = a.Id;
               var c = crudBussines.Retrieve<BussinesManager>(bussines);

                if (c != null)
                {
                    //BussinesManager  already exist
                    throw new BussinessException(1);
                }

                else
                {
                    bussines.Id_Address = a.Id;
                    crudBussines.Create(bussines);
                }
                     
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<BussinesManager> RetrieveAll()
        {

            var b = crudBussines.RetrieveAll<BussinesManager>();

            foreach (var bussines in b)
            {
                if (bussines.State==true)
                {
                    bussines.Active = "Activado";

                }
                else
                {
                    bussines.Active = "Desactivado";

                }



            }
            return b;
        }

        public BussinesManager RetrieveById(BussinesManager bussines)
        {
            BussinesManager c = null;
            try
            {
                c = crudBussines.Retrieve<BussinesManager>(bussines);
                if (c == null)
                {
                    throw new BussinessException(1);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return c;
        }

        public void Update(BussinesManager bussines)
        {
            crudBussines.Update(bussines);
        }

        public void Delete(BussinesManager bussines)
        {
            crudBussines.Delete(bussines);
        }
    }
}
