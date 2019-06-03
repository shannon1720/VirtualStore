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
    public class CartController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Get(String email)
        {

            apiResp = new ApiResponse();
            var mng = new CartManager();

            var cart = new Cart
            {
                Email = email
            };

            apiResp.Data = mng.RetrieveByEmail(cart);

            return Ok(apiResp);
        }


        public IHttpActionResult Post(Cart cart)
        {

            try
            {
                var mng = new CartManager();
                mng.Create(cart);
                apiResp = new ApiResponse();
                apiResp.Message = "Se ha registrado correctamente.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Delete(Cart cart)
        {
            try
            {
                var mng = new CartManager();
                mng.Delete(cart);
                apiResp = new ApiResponse();
                apiResp.Message = "";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

    }
}
