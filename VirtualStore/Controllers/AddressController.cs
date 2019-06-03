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
    public class AddressController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Post(Address bussiness)
        {

            try
            {
                var mng = new AddressManager();
                mng.Create(bussiness);

                apiResp = new ApiResponse
                {
                    //Message = "Action was executed."
                };

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        // GET api/bussinesManager
        public IHttpActionResult Get(int Id_Address)
        {
            try
            {
                var mng = new AddressManager();
                var address = new Address
                {
                    Id = Id_Address
                };

                address = mng.RetrieveById(address);
                apiResp = new ApiResponse();
                apiResp.Data = address;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Put(Address address)
        {

            try
            {
                var mng = new AddressManager();
                mng.Update(address);

                apiResp = new ApiResponse
                {
                    //Message = "Action was executed."
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
