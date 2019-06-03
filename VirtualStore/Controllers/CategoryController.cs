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
    public class CategoryController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        // GET api/category
        public IHttpActionResult Get()
        {

            apiResp = new ApiResponse();
            var mng = new CategoryManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }


        // GET by id
        public IHttpActionResult Get(int id)
        {
            try
            {
                var mng = new CategoryManager();
                var category = new Category
                {
                    ID = id
                };

                category = mng.RetrieveById(category);
                apiResp = new ApiResponse();
                apiResp.Data = category;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // GET by name
        public IHttpActionResult Get(string Name)
        {
            try
            {
                var mng = new CategoryManager();
                var category = new Category
                {
                    Name = Name
                };

                category = mng.RetrieveByName2(category);
                apiResp = new ApiResponse();
                apiResp.Data = category;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        //Get by state
        public IHttpActionResult Get(bool Active)
        {
            try
            {
                var mng = new CategoryManager();
                var category = new Category
                {
                    Active = Active
                };

                apiResp.Data = mng.RetrieveByState(category);

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // POST 
        public IHttpActionResult Post([FromBody]Category category)
        {
            try
            {
                var mng = new CategoryManager();
                mng.Create(category);

                apiResp = new ApiResponse();
                apiResp.Message = "Categoría registrada exitosamente.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                if (bex.ExceptionId == 3)
                {
                    return BadRequest("La categoria ya se encuentra registrada.");
                }
                return BadRequest("Solicitud Invalida");
            }
        }

        // PUT
        public IHttpActionResult Put(Category category)
        {
            try
            {
                var mng = new CategoryManager();
                mng.Update(category);

                apiResp = new ApiResponse();
                apiResp.Message = "Categoría modificada exitosamente.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // DELETE 
        public IHttpActionResult Delete(Category category)
        {
            try
            {
                var mng = new CategoryManager();
                mng.Delete(category);

                apiResp = new ApiResponse();
                //apiResp.Message = "Estado modificado.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}
