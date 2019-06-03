using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using CoreAPI;

namespace WebAPI.Controllers
{
    [ExceptionFilter]
    public class CurrencyController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        // GET api/Proyect
        public IHttpActionResult Get()
        {

            apiResp = new ApiResponse();
            var mng = new CurrencyManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

    }
}
