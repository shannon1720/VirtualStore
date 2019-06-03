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
    public class Recipe_CartController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        public IHttpActionResult Post(Recipe_Cart recipe_cart)
        {

            try
            {
                var mng = new Recipe_CartManager();
                mng.Create(recipe_cart);

                apiResp = new ApiResponse
                {
                    Message = "Lo logaste!."
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
