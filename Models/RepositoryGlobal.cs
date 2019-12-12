using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceM9UF3.Models;

namespace WebServiceM9UF3.Models
{
    public abstract class RepositoryGlobal
    {
        public static Contactes2Entities dataContext = new Contactes2Entities();
    }
}