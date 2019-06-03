using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcess.Crud;
using Entities_POJO;
using Exceptions;

namespace CoreAPI
{
    public class AdvertisingManager : BaseManager
    {
        AdvertisingCrudFactory crudAds;

        public AdvertisingManager()
        {
            crudAds = new AdvertisingCrudFactory();
        }

        public void Create(Advertising ads)
        {

            crudAds.Create(ads);

        }

        public Advertising RetrieveById(Advertising ads)
        {
            Advertising p = null;
            try
            {
                p = crudAds.Retrieve<Advertising>(ads);
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

        public List<Advertising> RetrieveAll()
        {
            var products = crudAds.RetrieveAll<Advertising>();
            return products;
        }

        public List<Advertising> RetrieveByName(Advertising ads)
        {
            return crudAds.RetrieveByName<Advertising>(ads);
        }

        public List<Advertising> RetrieveByState(Advertising ads)
        {
            return crudAds.RetrieveByState<Advertising>(ads);
        }

        public void Update(Advertising ads)
        {
            crudAds.Update(ads);
        }

        public void Delete(Advertising ads)
        {
            crudAds.Delete(ads);
        }
    }
}
