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
    public class SellerStoreManager : BaseManager
    {
        private SellerStoreCrudFactory crudSeller;
        private CrudFactoryAddress crudAddress;

        public SellerStoreManager()
        {
            crudSeller = new SellerStoreCrudFactory();
            crudAddress = new CrudFactoryAddress();
        }

        public void Create(SellerStore seller)
        {
            try
            {
                Address a = crudAddress.Retrieve<Address>(seller);
                seller.ID_Address = a.Id;
                var s = crudSeller.Retrieve<SellerStore>(seller);
                if (s != null)
                {
                    //SellerStore already exist
                    throw new BussinessException(3);
                }
                else {
                    seller.ID_Address = a.Id;
                    crudSeller.Create(seller);

                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<SellerStore> RetrieveAll()
        {

            var s = crudSeller.RetrieveAll<SellerStore>();

            foreach (var seller in s)
            {
                if (seller.Active == true)
                {
                    seller.State = "Activado";

                }
                else
                {
                    seller.State = "Desactivado";

                }
            }
            return s;
        }

        public SellerStore RetrieveById(SellerStore seller)
        {
            SellerStore s = null;
            try
            {
                s = crudSeller.Retrieve<SellerStore>(seller);
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

        public List<SellerStore> RetrieveByState(SellerStore seller)
        {
            return crudSeller.RetrieveByState<SellerStore>(seller);
        }

        public void Update(SellerStore seller)
        {
            crudSeller.Update(seller);
        }

        public void Delete(SellerStore seller)
        {
            crudSeller.Delete(seller);
        }
    }
}
