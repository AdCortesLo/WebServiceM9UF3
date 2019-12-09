using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebServiceM9UF3.Models;

namespace WebServiceM9UF3.Models
{
    public class EmailsController : ApiController
    {
        [HttpGet]
        [Route("api/emailC/{email?}")]
        public HttpResponseMessage Get(string email)
        {
            var emails = EmailsRepository.GetEmailByName(email);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, emails);
            return response;
        }

        [HttpPut]
        [Route("api/email/{id?}")]
        public HttpResponseMessage Put(int id, [FromBody]email val)
        {
            var contacte = EmailsRepository.UpdateEmail(id, val);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, contacte);
            return response;
        }

        [HttpPost]
        [Route("api/email")]
        public HttpResponseMessage Post([FromBody]email em)
        {
            var email = EmailsRepository.InsertEmail(em);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, email);
            return response;
        }

        [HttpDelete]
        [Route("api/email/{id?}")]
        public HttpResponseMessage Delete(int id)
        {
            EmailsRepository.DeleteEmail(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
    }
}