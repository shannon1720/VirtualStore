using CoreAPI;
using Entities_POJO;
using Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class UserCodeController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Post(UserCode code)
        {
            try
            {
                var mng = new UserCodeManager();
                mng.ValidateCode(code);

                apiResp = new ApiResponse();
                apiResp.Message = "correcto.";

                return Ok(apiResp); 
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}
