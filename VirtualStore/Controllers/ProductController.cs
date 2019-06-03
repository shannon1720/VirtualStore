using CoreAPI;
using Entities_POJO;
using Exceptions;
using System;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{

    [ExceptionFilter]

    public class ProductController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        // GET api/Proyect
        public IHttpActionResult Get()
        {

            apiResp = new ApiResponse();
            var mng = new ProductManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        // GET api/Proyect/Id
        public IHttpActionResult Get(int id)
        {
            try
            {
                var mng = new ProductManager();
                var product = new Product
                {
                    Id = id
                };

                apiResp.Data = mng.RetrieveById(product);

                return Ok(apiResp);

            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // GET api/Proyect/Name
        public IHttpActionResult Get(string name)
        {
            try
            {
                var mng = new ProductManager();
                var product = new Product
                {
                    Name = name
                };

                apiResp.Data = mng.RetrieveByName(product);

                return Ok(apiResp);

            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // GET api/Proyect/State
        public IHttpActionResult Get(bool state)
        {
            try
            {
                var mng = new ProductManager();
                var product = new Product
                {
                    State = state
                };

                apiResp.Data = mng.RetrieveByState(product);

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // POST 
        public IHttpActionResult Post(Product product)
        {

            try
            {
                var mng = new ProductManager();
                product.State = true;
                mng.Create(product);

                apiResp = new ApiResponse
                {
                    Message = "Action was executed."
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // PUT
        public IHttpActionResult Put(Product product)
        {
            try
            {
                var mng = new ProductManager();
                mng.Update(product);

                apiResp = new ApiResponse
                {
                    Message = "Action was executed."
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // DELETE 
        public IHttpActionResult Delete(Product proyect)
        {
            try
            {
                var mng = new ProductManager();
                mng.Delete(proyect);

                apiResp = new ApiResponse
                {
                    Message = "Action was executed."
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
