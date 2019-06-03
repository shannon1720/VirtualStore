using System;
using System.Collections.Generic;
using DataAcess.Crud;
using Entities_POJO;
using Exceptions;

namespace CoreAPI
{
    public class StoreManager : BaseManager
    {
        private StoreCrudFactory storeCrud;

        public StoreManager()
        {
            storeCrud = new StoreCrudFactory();
        }

        public void Create(Store storeAdmin)
        {
            try
            {
                var s = this.storeCrud.Retrieve<Store>(storeAdmin);

                if (s != null)
                {
                    throw new BussinessException(3);
                }
                else
                {
                    this.storeCrud.Create(storeAdmin);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Store> RetrieveAll()
        {
            return storeCrud.RetrieveAll<Store>();
        }

        public Store RetrieveByEmail(Store storeAdministrator)
        {
            Store s = null;

            try
            {
                s = storeCrud.Retrieve<Store>(storeAdministrator);

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

        public void Update(Store storeAdministrator)
        {
            storeCrud.Update(storeAdministrator);
        }

        public void Delete(Store store)
        {
            storeCrud.Delete(store);
        }
    }
}
