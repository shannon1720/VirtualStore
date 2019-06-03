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

    public class ProductMediaController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        // GET api/Proyect/Id
        public IHttpActionResult Get(int id)
        {
            try
            {
                var mng = new ProductMediaManager();
                var productMedia = new ProductMedia
                {
                    Id = id
                };

                apiResp.Data = mng.RetrieveById(productMedia);

                return Ok(apiResp);

            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        
        // POST 
        public IHttpActionResult Post(ProductMedia productMedia)
        {

            try
            {
                var mng = new ProductMediaManager();
                if (productMedia.Image2 == null)
                {
                    productMedia.Image2 = "";
                }

                if (productMedia.Image3 == null)
                {
                    productMedia.Image3 = "";
                }
                if (productMedia.Image4 == null)
                {
                    productMedia.Image4 = "";
                }

                if (productMedia.Image5 == null)
                {
                    productMedia.Image5 = "";
                }

                if (productMedia.Video == null)
                {
                    productMedia.Video = "";
                }

                productMedia.Active = true;
                mng.Create(productMedia);

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
        public IHttpActionResult Put(ProductMedia productMedia)
        {
            try
            {
                var mng = new ProductMediaManager();
                mng.Update(productMedia);

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
