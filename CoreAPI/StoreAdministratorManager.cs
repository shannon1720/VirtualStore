using System;
using System.Collections.Generic;
using DataAcess.Crud;
using Entities_POJO;
using Exceptions;

namespace CoreAPI
{
    public class StoreAdministratorManager : BaseManager
    {
        private StoreAdministratorCrudFactory storeAdmin;

        public StoreAdministratorManager()
        {
            storeAdmin = new StoreAdministratorCrudFactory();
        }

        public void Create(StoreAdministrator storeAdmin)
        {
            try
            {
                var d = this.storeAdmin.Retrieve<StoreAdministrator>(storeAdmin);

                if (d != null)
                {
                    throw new BussinessException(3);
                }
                else
                {
                    this.storeAdmin.Create(storeAdmin);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<StoreAdministrator> RetrieveAll()
        {
           
            var s = storeAdmin.RetrieveAll<StoreAdministrator>();

            foreach (var storeAdmin in s)
            {

                if (storeAdmin.Active)
                {

                    storeAdmin.State = "Activado";
                }
                else { storeAdmin.State = "Desactivado"; };

            }

            return s;
        }

        public StoreAdministrator RetrieveByEmail(StoreAdministrator storeAdministrator)
        {
            StoreAdministrator sa = null;

            try
            {
                sa = storeAdmin.Retrieve<StoreAdministrator>(storeAdministrator);

                if (sa == null)
                {
                    throw new BussinessException(4);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return sa;
        }

        public void Update(StoreAdministrator storeAdministrator)
        {
            storeAdmin.Update(storeAdministrator);
        }

        public void Delete(StoreAdministrator StoreAdmin)
        {
            storeAdmin.Delete(StoreAdmin);
        }

        public Store RetrieveStoreByEmail(StoreAdministrator StoreAdmin)
        {
            Store sa = null;

            try
            {
                sa = storeAdmin.RetrieveStoreByEmail<Store>(StoreAdmin);

                if (sa == null)
                {
                    throw new BussinessException(4);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return sa;
        }
    }
}
