
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
    public class UserPasswordController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Put(Password password)
        {
            try
            {
                var mng = new PasswordManager();
                mng.Update(password);

                apiResp = new ApiResponse();
                apiResp.Message = "Contraseña modificada.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Get(string email)
        {
            try
            {
                var mng = new PasswordManager();
                var seller = new Password
                {
                    Email = email
                };

                seller = mng.RetrieveById(seller);
                apiResp = new ApiResponse();
                apiResp.Data = seller;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}
