using CoreAPI;
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
    public class ConnectionController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        // GET api/shipping
        public IHttpActionResult Get()
        {
            try
            {
                var mng = new ConnecctionManager();
                mng.validate();
                apiResp = new ApiResponse();
               apiResp.Message = "Se conecto.";

                return Ok(apiResp);
             
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}
