using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceM9UF3.Models
{
    public partial class contacte
    {
        public bool serializarEmail = true;
        public bool serializarTelefon = true;

        public bool ShouldSerializeemails()
        {
            return this.serializarEmail;
        }

        public bool ShouldSerializetelefons()
        {
            return this.serializarTelefon;
        }
    }
}