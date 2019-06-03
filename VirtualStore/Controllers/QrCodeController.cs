using CoreAPI;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using Entities_POJO;

namespace WebAPI.Controllers
{

    [ExceptionFilter]
    public class QrCodeController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        // POST: api/QrCode
        public IHttpActionResult Post(QRCode request)
        {
            try
            {
                var mng = new QrCodeManager();
                apiResp.Data = mng.GenerateQRCode(request.Path);

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }


    }
}
