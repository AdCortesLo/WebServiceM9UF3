using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceM9UF3.Models
{
    public partial class telefon
    {
        [JsonIgnore]
        public bool serializeContacte = true;

        public bool ShouldSerializecontacte()
        {
            return this.serializeContacte;
        }
    }
}