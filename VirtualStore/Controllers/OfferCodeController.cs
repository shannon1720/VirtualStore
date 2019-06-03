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
    public class OfferCodeController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        // GET api/Proyect
        public IHttpActionResult Get()
        {

            apiResp = new ApiResponse();
            var mng = new OfferCodeManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        // GET api/Proyect/Id
        public IHttpActionResult Get(int id)
        {
            try
            {
                var mng = new OfferCodeManager();
                var offerCode = new OfferCode
                {
                    Id = id
                };

                apiResp.Data = mng.RetrieveById(offerCode);

                return Ok(apiResp);

            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // GET api/Proyect/Name
        public IHttpActionResult Get(string code)
        {
            try
            {
                var mng = new OfferCodeManager();
                var offerCode = new OfferCode
                {
                    Code = code
                };

                apiResp.Data = mng.RetrieveByName(offerCode);

                return Ok(apiResp);

            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // GET api/Proyect/State
        public IHttpActionResult Get(bool active)
        {
            try
            {
                var mng = new OfferCodeManager();
                var offerCode = new OfferCode
                {
                    Active = active
                };

                apiResp.Data = mng.RetrieveByState(offerCode);

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // POST 
        public IHttpActionResult Post(OfferCode offerCode)
        {

            try
            {
                var mng = new OfferCodeManager();
                offerCode.Active = true;
                mng.Create(offerCode);

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
        public IHttpActionResult Put(OfferCode offerCode)
        {
            try
            {
                var mng = new OfferCodeManager();
                mng.Update(offerCode);

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
        public IHttpActionResult Delete(OfferCode proyect)
        {
            try
            {
                var mng = new OfferCodeManager();
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
