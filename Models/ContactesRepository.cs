using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceM9UF3.Models;

namespace WebServiceM9UF3
{
    public class ContactesRepository
    {
        
        private static ProvesDavidEntities provesDavidEntities = new ProvesDavidEntities();

        public static Alumne GetAlumne(int idA)
        {
            Alumne a = provesDavidEntities.Alumnes.Where(x => x.id == idA).SingleOrDefault();
            return a;
        }

        public static List<contacte> GetAllContactes()
        {
            List<contacte> lc = RepositoryGlobal.dataContext.contactes.ToList().OrderBy(x => x.cognoms).ThenBy(x => x.nom).ToList();
            return lc;
        }

              
        public static contacte GetContacte(int contacteID)
        {
            contacte c = RepositoryGlobal.dataContext.contactes.Where(x => x.contacteId == contacteID).SingleOrDefault();
            return c;
        }

        public static List<contacte> SearchContactesByName(string contacteName)
        {
            List<contacte> lc = RepositoryGlobal.dataContext.contactes.Where(x => x.nom.Contains(contacteName) || x.cognoms.Contains(contacteName)).OrderBy(x => x.cognoms).ThenBy(x => x.nom).ToList();
            return lc;
        }

        public static contacte InsertContacte(contacte c)
        {
            try
            {
                RepositoryGlobal.dataContext.contactes.Add(c);
                RepositoryGlobal.dataContext.SaveChanges();
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
                    RepositoryGlobal.dataContext.contactes.Add(c);
                    RepositoryGlobal.dataContext.SaveChanges();
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
                contacte c0 = RepositoryGlobal.dataContext.contactes.Where(x => x.contacteId == id).SingleOrDefault();
                if (c.nom != null) c0.nom = c.nom;
                if (c.cognoms != null) c0.cognoms = c.cognoms;

                RepositoryGlobal.dataContext.SaveChanges();
                return GetContacte(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static void DeleteContacteTot(int id)
        {
            contacte c = RepositoryGlobal.dataContext.contactes.Where(x => x.contacteId == id).SingleOrDefault();
            if (c != null)
            {
                if (c.telefons != null)
                    RepositoryGlobal.dataContext.telefons.RemoveRange(c.telefons);
                if (c.emails != null)
                    RepositoryGlobal.dataContext.emails.RemoveRange(c.emails);
                RepositoryGlobal.dataContext.contactes.Remove(c);
                RepositoryGlobal.dataContext.SaveChanges();
            }
        }

        public static void DeleteContacte(int id)
        {
            contacte c = RepositoryGlobal.dataContext.contactes.Where(x => x.contacteId == id).SingleOrDefault();
            if (c != null)
            {
                if (c.telefons.Count == 0 && c.telefons.Count == 0)
                {
                    RepositoryGlobal.dataContext.contactes.Remove(c);
                    RepositoryGlobal.dataContext.SaveChanges();
                }
            }
        }

    }
}