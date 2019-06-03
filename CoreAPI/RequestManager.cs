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
    public class RequestManager : BaseManager
    {
        private RequestCrudFactory crudRequest;

        public RequestManager()
        {
            crudRequest = new RequestCrudFactory();
        }

        public void Create(Request request)
        {
            try
            {
                crudRequest.Create(request);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public void Delete(Request request)
        {
            crudRequest.Delete(request);
        }

        public Request Retrieve(Request request)
        {
            return crudRequest.Retrieve<Request>(request);
        }

        public List<Request> RetrieveAll()
        {
            return crudRequest.RetrieveAll<Request>();
        }

        public List<Request> RetrieveByEmail(Request request)
        {
            return crudRequest.RetrieveByEmail<Request>(request);
        }

    }
}
