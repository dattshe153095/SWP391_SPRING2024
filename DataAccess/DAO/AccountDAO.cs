using Business;
using Business.Models;
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
            return GetAllAccount().FirstOrDefault(x => x.username == username && x.password == password);
        }

        public static Account GetAccountWithId(int? id)
        {
            return GetAllAccount().FirstOrDefault(x => x.id == id);
        }

        public static Account GetAccountWithUsernameMail(string email)
        {
            return GetAllAccount().FirstOrDefault(x => x.email == email);
        }

        public static bool CheckAccountExist(string user)
        {
            Account acc = GetAllAccount().FirstOrDefault(x => x.username == user);
            return acc != null ? true : false;
        }

        public static void Register(Account account)
        {
            account.create_at = DateTime.Now;
            account.update_at = DateTime.Now;

            using (var context = new Web_Trung_GianContext())
            {
                var accounts = context.Set<Account>();
                accounts.Add(account);
                context.SaveChanges();
            }

            int id_wallet = Login(account.username, account.password).id;
            Wallet w = new Wallet()
            {
                balance = 0,
                account_id = account.id,
                update_at = DateTime.Now,
                update_by = id_wallet,
            };
            using (var context = new Web_Trung_GianContext())
            {
                var wallets = context.Set<Wallet>();
                wallets.Add(w);
                context.SaveChanges();
            }
        }

        public static void UpdateAccount(Account account)
        {
            try
            {
                account.update_at = DateTime.Now;
                Account c = GetAccountWithId(account.id);
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
                    account.is_delete = true;
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

        public static List<Account> GetAccountWithUsername(string? username)
        {
            return GetAllAccount().Where(x => x.username.Contains(username.Trim())).ToList();
        }

        public static Account GetAccountWithUser(string? username)
        {
            return GetAllAccount().FirstOrDefault(x => x.username == username);
        }
        public static Account GetAccountWithRole(int role)
        {
            return GetAllAccount().FirstOrDefault(x => x.role_id == role);
        }
    }
}
