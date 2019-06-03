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
    public class ShippingManager
    {

        private CrudFactoryShipping crudShipping;

        public ShippingManager()
        {
            crudShipping = new CrudFactoryShipping();
        }

        public void Create(Shipping shipping)
        {
            try
            {
                var c = crudShipping.Retrieve<Shipping>(shipping);

                if (c != null)
                {
                    //shipping  already exist
                    throw new BussinessException(3);
                }
                else
                {
                    crudShipping.Create(shipping);
                }

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Shipping> RetrieveAll()
        { var c = crudShipping.RetrieveAll<Shipping>();

            foreach (var shipping in c) {

                if (shipping.Active)
                {

                    shipping.State = "Activado";
                }
                else { shipping.State = "Desactivado"; };

            }

            return c;


        }

        public Shipping RetrieveById(Shipping shipping)
        {
            Shipping c = null;
            try
            {
                c = crudShipping.RetrieveByEmail1<Shipping>(shipping);
                if (c == null)
                {
                    throw new BussinessException(4);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return c;
        }

        public List<Shipping> RetrieveByEmail(Shipping shipping)
        {
            return crudShipping.RetrieveByEmail<Shipping>(shipping);
        }


        public void Update(Shipping shipping)
        {
            crudShipping.Update(shipping);
        }

        public void Delete(Shipping shipping)
        {
            crudShipping.Delete(shipping);
        }





    }
}
