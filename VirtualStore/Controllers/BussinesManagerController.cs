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
{   [ExceptionFilter]
    public class BussinesManagerController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        // GET api/bussinesManager
        public IHttpActionResult Get()
        {

            apiResp = new ApiResponse();
            var mng = new BussinesManageManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }


        // GET api/bussinesManager
        public IHttpActionResult Get(string email)
        {
            try
            {
                var mng = new BussinesManageManager();
                var bussines= new BussinesManager
                {
                   Email = email
                };

                bussines = mng.RetrieveById(bussines);
                apiResp = new ApiResponse();
                apiResp.Data = bussines;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }


        // POST 
        public async System.Threading.Tasks.Task<IHttpActionResult> PostAsync(BussinesManager bussiness)
        {
            var mngEmail = new EmailManager();
            var email = new Email
            {
                Mail = bussiness.Email,
                Name_1 = bussiness.Name_1,
                Last_Name_1 = bussiness.LastName_1
            };
            await mngEmail.Send(email);

            try
            {
                var mng = new BussinesManageManager();


                if (bussiness.Phone_2 == "" || bussiness.Phone_2 == null)
                {
                    bussiness.Phone_2 = "";
                }
                if (bussiness.LastName_2 == "" || bussiness.LastName_2 == null)
                {
                    bussiness.LastName_2 = "";
                }
                if (bussiness.Name_2 == "" || bussiness.Name_2 == null)
                {
                    bussiness.Name_2 = "";
                }
                mng.Create(bussiness);

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
        public IHttpActionResult Put(BussinesManager bussiness)
        {
            try
            {
                if (bussiness.Phone_2 == "" || bussiness.Phone_2 == null)
                {
                    bussiness.Phone_2 = "";
                }
                if (bussiness.LastName_2 == "" || bussiness.LastName_2 == null)
                {
                    bussiness.LastName_2 = "";
                }
                if (bussiness.Name_2 == "" || bussiness.Name_2 == null)
                {
                    bussiness.Name_2 = "";
                }
                
                var mng = new BussinesManageManager();
                mng.Update(bussiness);

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
        public IHttpActionResult Delete(BussinesManager bussiness)
        {
            try
            {
                var mng = new BussinesManageManager();
                mng.Delete(bussiness);

                apiResp = new ApiResponse();
               apiResp.Message = "Se ha "+bussiness.Active+" '" + bussiness.Email+ "' correctamente.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

    }
}
