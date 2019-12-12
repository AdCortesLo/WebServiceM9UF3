using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceM9UF3.Models
{
    public class EmailsRepository
    {
        public static Contactes2Entities dataContext = new Contactes2Entities();

        public static List<email> GetEmailByName(string name)
        {
            return RepositoryGlobal.dataContext.emails.Where(x => x.email1.Contains(name)).ToList();
        }
        public static email UpdateEmail(int id, email t)
        {
            try
            {
                email t0 = RepositoryGlobal.dataContext.emails.Where(x => x.emailId == id).SingleOrDefault();
                if (t.email1 != null)
                    t0.email1 = t.email1;
                if (t.tipus != null)
                    t0.tipus = t.tipus;

                RepositoryGlobal.dataContext.SaveChanges();
                return GetEmail(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static email GetEmail(int id)
        {
            email t = RepositoryGlobal.dataContext.emails.Where(x => x.emailId == id).SingleOrDefault();
            return t;
        }

        public static email InsertEmail(email em)
        {
            try
            {
                RepositoryGlobal.dataContext.emails.Add(em);
                RepositoryGlobal.dataContext.SaveChanges();
                return GetEmail(em.emailId);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static void DeleteEmail(int id)
        {
            email c = RepositoryGlobal.dataContext.emails.Where(x => x.emailId == id).SingleOrDefault();
            if (c != null)
            {
                RepositoryGlobal.dataContext.emails.Remove(c);
                RepositoryGlobal.dataContext.SaveChanges();
            }
        }
    }
}