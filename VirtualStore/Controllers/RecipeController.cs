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
    public class RecipeController : ApiController
    {


        ApiResponse apiResp = new ApiResponse();


        public IHttpActionResult Get()
        {

            apiResp = new ApiResponse();
            var mng = new RecipeManager();
            apiResp.Data = mng.Retrieve();

            return Ok(apiResp);
        }
        public IHttpActionResult Post(Recipe recipe)
        {

            try
            {
                var mng = new RecipeManager();
                mng.Create(recipe);

                apiResp = new ApiResponse
                {
                    Message = "Haz finalizado la compra exitosamente."
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
