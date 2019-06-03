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
            return storeAdmin.RetrieveAll<StoreAdministrator>();
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
    }
}
