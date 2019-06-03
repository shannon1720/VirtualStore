using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entities_POJO;
using WebAPI.Models;
using CoreAPI;
using Exceptions;


namespace WebAPI.Controllers
{
    [ExceptionFilter]
    public class StoreAdministratorController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Get()
        {
            var mng = new StoreAdministratorManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        public IHttpActionResult Get(string email)
        {
            try
            {
                var mng = new StoreAdministratorManager();
                var storeAdmin = new StoreAdministrator
                {
                    Email = email
                };

                storeAdmin = mng.RetrieveByEmail(storeAdmin);
                apiResp = new ApiResponse();
                apiResp.Data = storeAdmin;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public async System.Threading.Tasks.Task<IHttpActionResult> PostAsync(StoreAdministrator storeAdmin)
        {

            var mngEmail = new EmailManager();
            var email = new Email
            {
                Mail = storeAdmin.Email,
                Name_1 = storeAdmin.Name_1,
                Last_Name_1 = storeAdmin.Last_Name1
            };
            await mngEmail.Send(email);

            try
            {
                var mng = new StoreAdministratorManager();
                mng.Create(storeAdmin);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Put(StoreAdministrator storeAdministrator)
        {
            try
            {
                var mng = new StoreAdministratorManager();
                mng.Update(storeAdministrator);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Delete(StoreAdministrator storeAdministrator)
        {
            try
            {
                var mng = new StoreAdministratorManager();
                
                mng.Delete(storeAdministrator);

                apiResp = new ApiResponse();
                apiResp.Message = "Se ha " + storeAdministrator.State + " '" + storeAdministrator.Email + "' correctamente.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        
    }
}
