using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebServiceM9UF3.Models;

namespace WebServiceM9UF3.Models
{
    public class TelefonsController : ApiController
    {
        [HttpGet]
        [Route("api/telefonC/{num?}")]
        public HttpResponseMessage Get(string num)
        {
            var telefons = TelefonsRepository.GetTelefonByNum(num);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, telefons);
            return response;
        }

        [HttpPut]
        [Route("api/telefon/{id?}")]
        public HttpResponseMessage Put(int id, [FromBody]telefon val)
        {
            var contacte = TelefonsRepository.UpdateTelefon(id, val);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, contacte);
            return response;
        }

        [HttpPost]
        [Route("api/telefon")]
        public HttpResponseMessage Post([FromBody]telefon tel)
        {
            var telefon = TelefonsRepository.InsertTelefon(tel);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, telefon);
            return response;
        }

        [HttpDelete]
        [Route("api/telefon/{id?}")]
        public HttpResponseMessage Delete(int id)
        {
            TelefonsRepository.DeleteTelefon(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

    }
}