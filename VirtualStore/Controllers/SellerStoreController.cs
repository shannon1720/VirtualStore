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
    public class SellerStoreController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        // GET api/SellerStore
        public IHttpActionResult Get()
        {

            apiResp = new ApiResponse();
            var mng = new SellerStoreManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        // GET by name
        public IHttpActionResult Get(string email)
        {
            try
            { 
                var mng = new SellerStoreManager();
                var seller = new SellerStore
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

        //Get by state
        //public IHttpActionResult Get(bool Active)
        //{
        //    try
        //    {
        //        var mng = new SellerStoreManager();
        //        var seller = new SellerStore
        //        {
        //            ACTIVE = Active
        //        };

        //        apiResp.Data = mng.RetrieveByState(seller);

        //        return Ok(apiResp);
        //    }
        //    catch (BussinessException bex)
        //    {
        //        return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
        //    }
        //}

        // POST 
        public async System.Threading.Tasks.Task<IHttpActionResult> PostAsync(SellerStore seller)
        {
            var mngEmail = new EmailManager();
            var email = new Email
            {
                Mail = seller.Email,
                Name_1 = seller.Name_1,
                Last_Name_1 = seller.Last_Name_1,
                Code = "P@as123s"
                
            };
            await mngEmail.Send(email);

            try
            {
                var mng = new SellerStoreManager();
                if (seller.Phone_2 == "" || seller.Phone_2 == null)
                {
                    seller.Phone_2 = "";
                }
                if (seller.Last_Name_2 == "" || seller.Last_Name_2 == null)
                {
                    seller.Last_Name_2 = "";
                }
                if (seller.Name_2 == "" || seller.Name_2 == null)
                {
                    seller.Name_2 = "";
                }
                mng.Create(seller);

                
                apiResp = new ApiResponse
                {
                    Message = "Vendedor registrado exitosamente."
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // PUT
        public IHttpActionResult Put(SellerStore selller)
        {
            try
            {
                var mng = new SellerStoreManager();
                mng.Update(selller);

                apiResp = new ApiResponse();
               // apiResp.Message = "Vendedor modificado exitosamente.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        //public IHttpActionResult Put(SellerStore selller)
        //{
        //    try
        //    {
        //        var mng = new SellerStoreManager();
        //        mng.UpdatePassword(selller);

        //        apiResp = new ApiResponse();
        //        apiResp.Message = "contraseña modificada.";

        //        return Ok(apiResp);
        //    }
        //    catch (BussinessException bex)
        //    {
        //        return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
        //    }
        //}

        // DELETE 
        public IHttpActionResult Delete(SellerStore seller)
        {
            try
            {
                var mng = new SellerStoreManager();
                mng.Delete(seller);

                apiResp = new ApiResponse();
               // apiResp.Message = "Estado modificado.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}
