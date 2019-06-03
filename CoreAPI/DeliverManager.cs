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
    public class DeliverManager : BaseManager
    {
        private DeliverCrudFactory crudDeliver;

        public DeliverManager()
        {
            crudDeliver = new DeliverCrudFactory();
        }

        public void Create(Deliver deliver)
        {
            try
            {
                var d = crudDeliver.Retrieve<Deliver>(deliver);

                if(d != null)
                {
                    throw new BussinessException(3);
                }
                else
                {
                    crudDeliver.Create(deliver);
                }
            }catch(Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Deliver> RetrieveAll()
        {
            var delivers = crudDeliver.RetrieveAll<Deliver>();
            foreach (var deliver in delivers)
            {
                if (deliver.Active == true)
                {
                     deliver.State = "Activado";

                }
                else
                {
                    deliver.State = "Desactivado";

                }
            }
            return delivers;
        }

        public List<Deliver> RetrieveByEmail(Deliver deliver)
        {
            var delivers = crudDeliver.RetrieveByEmail<Deliver>(deliver);
            foreach (var del in delivers)
            {
                if (del.Active == true)
                {
                    del.State = "Activado";

                }
                else
                {
                    del.State = "Desactivado";

                }
            }
            return delivers;
        }

        public void Update(Deliver deliver)
        {
            crudDeliver.Update(deliver);
        }

        public void Delete(Deliver deliver)
        {
            crudDeliver.Delete(deliver);
        }
    }
}
