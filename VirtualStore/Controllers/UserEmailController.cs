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
    public class UserEmailController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        public async System.Threading.Tasks.Task<IHttpActionResult> PostAsync(Email email)
        {
            try
            {
                var mng = new EmailManager();
                await mng.Send(email);

                apiResp = new ApiResponse();
                apiResp.Message = "Email enviado.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}
