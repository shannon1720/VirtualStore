using DataAcess.Crud;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;

namespace CoreAPI
{
    public class OfferCodeManager : BaseManager
    {
        private OfferCodeCrudFactory crudProduct;

        public OfferCodeManager()
        {
            crudProduct = new OfferCodeCrudFactory();
        }

        public void Create(OfferCode offerCode)
        {

            crudProduct.Create(offerCode);

        }

        public OfferCode RetrieveById(OfferCode offerCode)
        {
            OfferCode p = null;
            try
            {
                p = crudProduct.Retrieve<OfferCode>(offerCode);
                if (p == null)
                {
                    throw new BussinessException(4);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return p;
        }

        public List<OfferCode> RetrieveAll()
        {

            var products = crudProduct.RetrieveAll<OfferCode>();
            return products;
        }

        public List<OfferCode> RetrieveByName(OfferCode offerCode)
        {
            return crudProduct.RetrieveByName<OfferCode>(offerCode);
        }

        public List<OfferCode> RetrieveByState(OfferCode offerCode)
        {
            return crudProduct.RetrieveByState<OfferCode>(offerCode);
        }

        public void Update(OfferCode offerCode)
        {
            crudProduct.Update(offerCode);
        }

        public void Delete(OfferCode offerCode)
        {
            crudProduct.Delete(offerCode);
        }
    }
}
