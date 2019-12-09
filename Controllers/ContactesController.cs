using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebServiceM9UF3.Models;

namespace WebServiceM9UF3.Controllers
{
    public class ContactesController : ApiController
    {
        // GET: api/contactes
        [HttpGet]
        [Route("api/contactes")]
        public HttpResponseMessage Get()
        {
            var contactes = ContactesRepository.GetAllContactes();

            foreach (var c in contactes)
            {
                c.serializarEmail = false;
                c.serializarTelefon = false;
            }
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, contactes);
            return response;
        }

        [HttpGet]
        [Route("api/contactesTot")]
        public HttpResponseMessage GetTot()
        {
            var contactes = ContactesRepository.GetAllContactes();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, contactes);
            return response;
        }

        [HttpGet]
        [Route("api/contactes/{name:alpha}")]
        public HttpResponseMessage Get(string name)
        {
            var contactes = ContactesRepository.SearchContactesByName(name);
            foreach (var c in contactes)
            {
                c.serializarEmail = false;
                c.serializarTelefon = false;
            }
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, contactes);
            return response;
        }

        [HttpGet]
        [Route("api/contactesTot/{name:alpha}")]
        public HttpResponseMessage GetTot(string name)
        {
            var contactes = ContactesRepository.SearchContactesByName(name);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, contactes);
            return response;
        }

        // GET: api/contacte/5
        [HttpGet]
        [Route("api/contacte/{id?}")]
        public HttpResponseMessage GetContacte(int id)
        {
            var contacte = ContactesRepository.GetContacte(id);
            contacte.serializarEmail = false;
            contacte.serializarTelefon = false;
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, contacte);
            return response;
        }

        [HttpGet]
        [Route("api/contacteTot/{id?}")]
        public HttpResponseMessage GetContacteTot(int id)
        {
            try
            {
                var contacte = ContactesRepository.GetContacte(id);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, contacte);
                return response;
            } catch (Exception ex)
            {
                return null;
            }
        }

        // PUT: api/contacte/5
        [HttpPut]
        [Route("api/contacte/{id?}")]
        public HttpResponseMessage Put(int id, [FromBody]contacte val)
        {
            var contacte = ContactesRepository.UpdateContacte(id, val);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, contacte);
            return response;
        }

        //POST: insert
        [HttpPost]
        [Route("api/contacte")]
        public HttpResponseMessage Post([FromBody]contacte cont)
        {
            var contactes = ContactesRepository.InsertContacte(cont);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, contactes);
            return response;
        }

        [HttpPost]
        [Route("api/contacteTot")]
        public HttpResponseMessage PostTot([FromBody]contacte cont)
        {
            var contactes = ContactesRepository.InsertContacteTot(cont);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, contactes);
            return response;
        }

        [HttpDelete]
        [Route("api/contacteTot/{id?}")]
        public HttpResponseMessage DeleteTot(int id)
        {
            ContactesRepository.DeleteContacteTot(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        [HttpDelete]
        [Route("api/contacte/{id?}")]
        public HttpResponseMessage Delete(int id)
        {
            ContactesRepository.DeleteContacte(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
    }
}