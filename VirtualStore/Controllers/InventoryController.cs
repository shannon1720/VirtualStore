using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using CoreAPI;
using Entities_POJO;
using Exceptions;

namespace WebAPI.Controllers
{

    [ExceptionFilter]
    public class InventoryController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Get()
        {
            var mng = new InventoryManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        public IHttpActionResult Get(string id)
        {
            int i;
            bool passed = int.TryParse(id, out i);
            try
            {
                var mng = new InventoryManager();
                var deliver = new Inventory
                {
                    Id = i
                };

                deliver = mng.RetrieveByEmail(deliver);
                apiResp = new ApiResponse();
                apiResp.Data = deliver;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Get(int IdCellar)
        {           
            try
            {
                var mng = new InventoryManager();
                
                var Inventory = new Inventory
                {
                    IdCellar = IdCellar
                };

                var products = mng.RetrieveByCellar(Inventory);
                foreach (var product in products)
                {
                    if (product.State == true)
                    {
                        product.Active = "Activado";

                    }
                    else
                    {
                        product.Active = "Desactivado";

                    }
                }

                apiResp = new ApiResponse();
                apiResp.Data = products;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Post(Inventory inventory)
        {

            try
            {
                var mng = new InventoryManager();
                mng.Create(inventory);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Put(Inventory inventory)
        {
            try
            {
                var mng = new InventoryManager();
                mng.Update(inventory);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Delete(Inventory inventory)
        {
            try
            {
                var mng = new InventoryManager();
                mng.Delete(inventory);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}
