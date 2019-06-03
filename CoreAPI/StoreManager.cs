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
                    this.storeCrud.Create(storeAdmin);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Store> RetrieveAll()
        {
            var s = storeCrud.RetrieveAll<Store>();

            foreach (var store in s)
            {

                if (store.Active)
                {

                    store.State = "Activado";
                }
                else { store.State = "Desactivado"; };

            }

            return s;
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

        public Store RetrieveCellarId(Store store)
        {
            Store s = null;

            try
            {
                s = storeCrud.Retrieve<Store>(store);

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

        public List<Store> RetrieveStoreByUserEmail(StoreAdministrator StoreAdministrator)
        {
            var clients = storeCrud.RetrieveStoreByUserEmail<Store>(StoreAdministrator);
            return clients;
        }
    }
}
