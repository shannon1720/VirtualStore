using CoreAPI;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ExceptionFilter]
    public class LogInController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Post(LogIn logIn)
        {
            var mng = new LogInManager();
            apiResp.Data = mng.initiate(logIn);

            return Ok(apiResp.Data);
        }
    }
}