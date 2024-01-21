using BussinessObject;
using BussinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class AccountDAO
    {
        public static List<Account> GetAllAccount()
        {
            List<Account> list = new List<Account>();

            using (var context = new Web_Trung_GianContext())
            {
                list = context.Accounts.ToList();

            }
            return list;
        }

        public static Account Login(string username, string password)
        {
            return GetAllAccount().FirstOrDefault(x => x.Username == username && x.Password == password);
        }

        public static Account GetAccountWithId(int? id)
        {
            return GetAllAccount().FirstOrDefault(x => x.Id == id);
        }

        public static bool CheckAccountExist(string user)
        {
            Account acc = GetAllAccount().FirstOrDefault(x => x.Username == user);
            return acc != null ? true : false;
        }

        public static void Register(Account account)
        {

            using (var context = new Web_Trung_GianContext())
            {
                var accounts = context.Set<Account>();
                accounts.Add(account);
                context.SaveChanges();
            }
        }

        public static void UpdateAccount(Account account)
        {
            try
            {
                Account c = GetAccountWithId(account.Id);
                if (c != null)
                {
                    using (var context = new Web_Trung_GianContext())
                    {
                        var accounts = context.Set<Account>();
                        accounts.Update(account);
                        context.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The Account does not exist");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteAccount(int id)
        {
            try
            {
                Account account = GetAccountWithId(id);
               
                if (account != null)
                {
                    account.IsDelete = true;
                    using (var context = new Web_Trung_GianContext())
                    {
                        var accounts = context.Set<Account>();
                        accounts.Update(account);
                        context.SaveChanges();
                    }

                }
            }
            catch (Exception)
            {
                throw new Exception("The category doesn't exist");
            }
        }
    }
}
