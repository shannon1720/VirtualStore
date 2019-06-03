using System;
using System.Web.Http;
using Entities_POJO;
using WebAPI.Models;
using Exceptions;
using CoreAPI;

namespace WebAPI.Controllers
{
    [ExceptionFilter]
    public class StoreController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Get()
        {
            var mng = new StoreManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        public IHttpActionResult Get(string id)
        {
            try
            {
                var mng = new StoreManager();
                var store = new Store
                {
                    Id = id
                };
                store = mng.RetrieveByEmail(store);
                apiResp = new ApiResponse();
                apiResp.Data = store;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        // Get store by user email 
        public IHttpActionResult Get(string email, string name)
        {
            try
            {
                var mng = new StoreManager();
                var storeAdministrator = new StoreAdministrator
                {
                     Email=email
                };

                var store = mng.RetrieveStoreByUserEmail(storeAdministrator);
                apiResp = new ApiResponse
                {
                    Data = store
                                
                };
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Post(Store store)
        {

            try
            {
                var mng = new StoreManager();
                mng.Create(store);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Put(Store store)
        {
            try
            {
                var mng = new StoreManager();
                mng.Update(store);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Delete(Store store)
        {
            try
            {
                var mng = new StoreManager();
               
                mng.Delete(store);

                apiResp = new ApiResponse();
                apiResp.Message = "Se ha " + store.State + " '" + store.Name + "' correctamente.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}
