using CoreAPI;
using Entities_POJO;
using Exceptions;
using System;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ExceptionFilter]
    public class ClientController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        // GET api/Proyect
        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new ClientManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        // GET api/Proyect/Email
        public IHttpActionResult Get(string email)
        {
            try
            {
                var mng = new ClientManager();
                var client = new Client
                {
                    Email = email
                };

                apiResp.Data = mng.RetrieveByEmail(client);

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
                var mng = new ClientManager();
                var client = new Client
                {
                    Active = active
                };

                apiResp.Data = mng.RetrieveByState(client);

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // POST 
        public async System.Threading.Tasks.Task<IHttpActionResult> PostAsync(Client client)
        {

            var mngEmail = new EmailManager();
            var email = new Email
            {
                Mail = client.Email,
                Name_1 = client.Name_1,
                Last_Name_1 = client.Last_Name_1
            };
            await mngEmail.Send(email);

            try
            {
                var mng = new ClientManager();
                if (client.Phone_2 ==""|| client.Phone_2 == null)
                {
                    client.Phone_2 = "";
                }
                if (client.Last_Name_2 == "" || client.Last_Name_2 == null)
                {
                    client.Last_Name_2 = "";
                }
                if (client.Name_2 == "" || client.Name_2== null)
                {
                    client.Name_2 = "";
                }
                mng.Create(client);

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
        public IHttpActionResult Put(Client client)
        {
            try
            {
                var mng = new ClientManager();
                mng.Update(client);

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
        public IHttpActionResult Delete(Client client)
        {
            try
            {
                var mng = new ClientManager();
                mng.Delete(client);

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
