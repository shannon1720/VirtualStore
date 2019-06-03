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
    public class ClientManager
    {
        private ClientCrudFactory crudProduct;

        public ClientManager()
        {
            crudProduct = new ClientCrudFactory();
        }

        public void Create(Client client)
        {

            crudProduct.Create(client);

        }

        public List<Client> RetrieveAll()
        {
            var clients = crudProduct.RetrieveAll<Client>();
            foreach (var client in clients)
            {
                if (client.Active == true)
                {
                    client.State = "Activado";

                }
                else
                {
                    client.State = "Desactivado";

                }
            }

            return clients;
        }

        public List<Client> RetrieveByEmail(Client client)
        {
            return crudProduct.RetrieveByEmail<Client>(client);
        }

        public List<Client> RetrieveByState(Client client)
        {
            return crudProduct.RetrieveByState<Client>(client);
        }

        public void Update(Client client)
        {
            crudProduct.Update(client);
        }

        public void Delete(Client client)
        {
            crudProduct.Delete(client);
        }
    }
}
