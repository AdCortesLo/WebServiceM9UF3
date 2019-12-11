using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceM9UF3.Models;

namespace WebServiceM9UF3
{
    public class ContactesRepository
    {
        private static Contactes2Entities dataContext = new Contactes2Entities();
        public static List<contacte> GetAllContactes()
        {
            List<contacte> lc = dataContext.contactes.ToList();
            return lc;
        }

              
        public static contacte GetContacte(int contacteID)
        {
            contacte c = dataContext.contactes.Where(x => x.contacteId == contacteID).SingleOrDefault();
            return c;
        }

        public static List<contacte> SearchContactesByName(string contacteName)
        {
            List<contacte> lc = dataContext.contactes.Where(x => x.nom.Contains(contacteName) || x.cognoms.Contains(contacteName)).ToList();
            return lc;
        }

        public static contacte InsertContacte(contacte c)
        {
            try
            {
                dataContext.contactes.Add(c);
                dataContext.SaveChanges();
                return GetContacte(c.contacteId);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static contacte InsertContacteTot(contacte c)
        {
            try
            {
                if (c.telefons.Count > 0 && c.emails.Count > 0)
                {
                    dataContext.contactes.Add(c);
                    dataContext.SaveChanges();
                    return GetContacte(c.contacteId);
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static contacte UpdateContacte(int id, contacte c)
        {
            try
            {
                contacte c0 = dataContext.contactes.Where(x => x.contacteId == id).SingleOrDefault();
                if (c.nom != null) c0.nom = c.nom;
                if (c.cognoms != null) c0.cognoms = c.cognoms;

                dataContext.SaveChanges();
                return GetContacte(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static void DeleteContacteTot(int id)
        {
            contacte c = dataContext.contactes.Where(x => x.contacteId == id).SingleOrDefault();
            if (c != null)
            {
                if (c.telefons != null)
                    dataContext.telefons.RemoveRange(c.telefons);
                if (c.emails != null)
                    dataContext.emails.RemoveRange(c.emails);
                dataContext.contactes.Remove(c);
                dataContext.SaveChanges();
            }
        }

        public static void DeleteContacte(int id)
        {
            contacte c = dataContext.contactes.Where(x => x.contacteId == id).SingleOrDefault();
            if (c != null)
            {
                if (c.telefons.Count == 0 && c.telefons.Count == 0)
                {
                    dataContext.contactes.Remove(c);
                    dataContext.SaveChanges();
                }
            }
        }

    }
}