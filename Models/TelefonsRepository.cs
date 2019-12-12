using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceM9UF3.Models
{
    public class TelefonsRepository
    {
        

        public static List<telefon> GetAllTelefons()
        {
            return RepositoryGlobal.dataContext.telefons.ToList();
        }

        public static List<telefon> GetTelefonByNum(string num)
        {
            return RepositoryGlobal.dataContext.telefons.Where(x => x.telefon1.Contains(num)).ToList();
        }

        public static telefon UpdateTelefon(int id, telefon t)
        {
            try
            {
                telefon t0 = RepositoryGlobal.dataContext.telefons.Where(x => x.telId == id).SingleOrDefault();
                if (t.telefon1 != null)
                    t0.telefon1 = t.telefon1;
                if (t.tipus != null)
                    t0.tipus = t.tipus;

                RepositoryGlobal.dataContext.SaveChanges();
                return GetTelefon(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static telefon GetTelefon(int id)
        {
            telefon t = RepositoryGlobal.dataContext.telefons.Where(x => x.telId == id).SingleOrDefault();
            return t;
        }

       public static telefon InsertTelefon (telefon tel)
        {
            try
            {
                RepositoryGlobal.dataContext.telefons.Add(tel);
                RepositoryGlobal.dataContext.SaveChanges();
                return GetTelefon(tel.telId);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static void DeleteTelefon(int id)
        {
            telefon c = RepositoryGlobal.dataContext.telefons.Where(x => x.telId == id).SingleOrDefault();
            if (c != null)
            {
                RepositoryGlobal.dataContext.telefons.Remove(c);
                RepositoryGlobal.dataContext.SaveChanges();
            }
        }
    }
}