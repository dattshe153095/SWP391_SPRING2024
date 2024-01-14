using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class AdminDAO
    {
        public static List<Admin> GetAllAdmin()
        {
            List<Admin> list = new List<Admin>();

            using (var context = new Web_Trung_GianContext())
            {
                list = context.Admins.ToList();

            }
            return list;
        }

        public static Admin LoginAdmin(string username, string password)
        {
            return GetAllAdmin().FirstOrDefault(x => x.Username == username && x.Password == password);
        }

        public static Admin GetAdminWithId(int? id)
        {
            return GetAllAdmin().FirstOrDefault(x => x.Id == id);
        }

        public static void UpdateAdmin(Admin admin)
        {
            try
            {
                Admin c = GetAdminWithId(admin.Id);
                if (c != null)
                {
                    using (var context = new Web_Trung_GianContext())
                    {
                        var accounts = context.Set<Admin>();
                        accounts.Update(admin);
                        context.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The Admin does not exist");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void AddAdmin(Admin admin)
        {

            using (var context = new Web_Trung_GianContext())
            {
                var accounts = context.Set<Admin>();
                accounts.Add(admin);
                context.SaveChanges();
            }
        }

    }
}
