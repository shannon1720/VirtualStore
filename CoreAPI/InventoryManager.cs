using DataAcess.Crud;
using System;
using System.Collections.Generic;
using Entities_POJO;
using Exceptions;

namespace CoreAPI
{
    public class InventoryManager : BaseManager
    {
        private InventoryCrudFactory crudInventory;

        public InventoryManager()
        {
            crudInventory = new InventoryCrudFactory();
        }

        public void Create(Inventory deliver)
        {
            try
            {

                crudInventory.Create(deliver);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Inventory> RetrieveAll()
        {
            return crudInventory.RetrieveAll<Inventory>();
        }

        public Inventory RetrieveByEmail(Inventory inventory)
        {
            Inventory i = null;

            try
            {
                i = crudInventory.Retrieve<Inventory>(inventory);

                if (i == null)
                {
                    throw new BussinessException(4);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return i;
        }

        public void Update(Inventory inventory)
        {
            crudInventory.Update(inventory);
        }

        public void Delete(Inventory inventory)
        {
            crudInventory.Delete(inventory);
        }


        public List<Product> RetrieveByCellar(Inventory inventory)
        {
            return crudInventory.RetrieveAllByCellar<Inventory>(inventory);

        }
    }
}
