using CoreAPI;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ExceptionFilter]

    public class RequestController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        // GET api/Proyect
        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new RequestManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }
        // GET api/Proyect/Email
        public IHttpActionResult Get(string email)
        {
            try
            {
                var mng = new RequestManager();
                var request = new Request
                {
                    IdUser = email
                };

                apiResp.Data = mng.RetrieveByEmail(request);

                return Ok(apiResp);

            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        // GET api/Proyect/Id
        public IHttpActionResult Get(int Id)
        {
            try
            {
                var mng = new RequestManager();
                var request = new Request
                {
                    Id = Id
                };

                apiResp.Data = mng.Retrieve(request);

                return Ok(apiResp);

            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        // POST 
        public IHttpActionResult Post(Request request)
        {
            try
            {
                var mng = new RequestManager();
                mng.Create(request);

                apiResp = new ApiResponse
                {
                    Message = "Action was executed."
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        // DELETE 
        public IHttpActionResult Delete(Request request)
        {
            try
            {
                var mng = new RequestManager();
                mng.Delete(request);

                apiResp = new ApiResponse
                {
                    Message = "Action was executed."
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}
