using CoreAPI;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{

    [ExceptionFilter]
    public class DeliverController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Get()
        {
            var mng = new DeliverManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        public IHttpActionResult Get(string email)
        {
            try
            {
                var mng = new DeliverManager();
                var deliver = new Deliver
                {
                    Email = email
                };

                List<Deliver> delivers = mng.RetrieveByEmail(deliver);
                apiResp = new ApiResponse();
                apiResp.Data = delivers;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public async System.Threading.Tasks.Task<IHttpActionResult> PostAsync(Deliver deliver)
        {
            var mngEmail = new EmailManager();
            var email = new Email
            {
                Mail = deliver.Email,
                Name_1 = deliver.Name_1,
                Last_Name_1 = deliver.Last_Name1
            };
            await mngEmail.Send(email);

            try
            {
                var mng = new DeliverManager();
                mng.Create(deliver);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Put(Deliver deliver)
        {
            try
            {
                var mng = new DeliverManager();
                mng.Update(deliver);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Delete(Deliver deliver)
        {
            try
            {
                var mng = new DeliverManager();
                mng.Delete(deliver);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}