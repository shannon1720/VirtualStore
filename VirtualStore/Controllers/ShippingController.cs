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
    public class ShippingController : ApiController
    {


        ApiResponse apiResp = new ApiResponse();

        // GET api/shipping
        public IHttpActionResult Get()
        {

            apiResp = new ApiResponse();
            var mng = new ShippingManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }


        // GET api/shipping/
        public IHttpActionResult Get(String email)
        {
            try
            {
                var mng = new ShippingManager();
                var shipping = new Shipping
                {
                    Email = email
                };

                shipping = mng.RetrieveById(shipping);
                apiResp = new ApiResponse();
                apiResp.Data = shipping;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Post(string email)
        {
            try
            {
                var mng = new ShippingManager();
                var shipping = new Shipping
                {
                    Email = email
                };

                List<Shipping> delivers = mng.RetrieveByEmail(shipping);
                apiResp = new ApiResponse();
                apiResp.Data = delivers;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }


        // POST 
        public async System.Threading.Tasks.Task<IHttpActionResult> PostAsync(Shipping shipping)
        {
            var mngEmail = new EmailManager();
            var email = new Email
            {
                Mail = shipping.Email,
                Name_1 = shipping.Name,
                Last_Name_1 = " "
            };
            await mngEmail.Send(email);

            try
            {
                var mng = new ShippingManager();
                mng.Create(shipping);

                apiResp = new ApiResponse();
                apiResp.Message = "Se ha registrado correctamente.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // PUT
        public IHttpActionResult Put(Shipping shipping)
        {
            try
            {
                var mng = new ShippingManager();
                mng.Update(shipping);

                apiResp = new ApiResponse();
                apiResp.Message = "Se ha actualizado correctamente.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // DELETE 
        public IHttpActionResult Delete(Shipping shipping)
        {
            try
            {
                var mng = new ShippingManager();
                mng.Delete(shipping);

                apiResp = new ApiResponse();
                apiResp.Message = "Se ha "+shipping.State+ " '" + shipping.Name + "' correctamente.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }





    }
}
