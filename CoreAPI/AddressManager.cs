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
    public class AddressManager
    {
       private CrudFactoryAddress crud= new CrudFactoryAddress();

        public void Create(Address bussines)
        {
            try
            {
                    crud.Create(bussines);
    
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public Address RetrieveById(Address address)
        {
            return crud.RetrieveId<Address>(address);
        }


        public void Update(Address address) {

            crud.Update(address);


        }
    }
}
