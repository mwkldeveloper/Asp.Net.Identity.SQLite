using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;

namespace AspNet.Identity.SQLite.EF
{
    /// <summary>
    /// Class that represents the AspNetUserLogins table in the SQLite Database
    /// </summary>
    public class UserLoginsTable
    {
        private SQLiteIdenitityDbContext _database;

        /// <summary>
        /// Constructor that takes a SQLiteIdenitityDbContext instance 
        /// </summary>
        /// <param name="database"></param>
        public UserLoginsTable(SQLiteIdenitityDbContext database)
        {
            _database = database;
        }

        /// <summary>
        /// Deletes a login from a user in the AspNetUserLogins table
        /// </summary>
        /// <param name="user">User to have login deleted</param>
        /// <param name="login">Login to be deleted from user</param>
        /// <returns></returns>
        public int Delete(IdentityUser user, UserLoginInfo login)
        {
            var userLogin = _database.AspNetUserLogins
                .Where(x => x.UserId == user.Id && x.LoginProvider == login.LoginProvider && x.ProviderKey == login.ProviderKey);
            _database.AspNetUserLogins.RemoveRange(userLogin);
            return _database.SaveChanges();
        }

        /// <summary>
        /// Deletes all Logins from a user in the AspNetUserLogins table
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// <returns></returns>
        public int Delete(string userId)
        {
            var userLogin = _database.AspNetUserLogins.Where(x => x.UserId == userId);
            _database.AspNetUserLogins.RemoveRange(userLogin);
            return _database.SaveChanges();
        }

        /// <summary>
        /// Inserts a new login in the AspNetUserLogins table
        /// </summary>
        /// <param name="user">User to have new login added</param>
        /// <param name="login">Login to be added</param>
        /// <returns></returns>
        public int Insert(IdentityUser user, UserLoginInfo login)
        {
            AspNetUserLogin userLogin = new AspNetUserLogin();
            userLogin.LoginProvider = login.LoginProvider;
            userLogin.ProviderKey = login.ProviderKey;
            userLogin.UserId = user.Id;
            _database.AspNetUserLogins.Add(userLogin);
            return _database.SaveChanges();
        }

        /// <summary>
        /// Return a userId given a user's login
        /// </summary>
        /// <param name="userLogin">The user's login info</param>
        /// <returns></returns>
        public string FindUserIdByLogin(UserLoginInfo userLogin)
        {
            return _database.AspNetUserLogins.Where(x => x.LoginProvider == userLogin.LoginProvider && x.ProviderKey == userLogin.ProviderKey)
                .Select(x => x.UserId).SingleOrDefault();
        }

        /// <summary>
        /// Returns a list of user's logins
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// <returns></returns>
        public List<UserLoginInfo> FindByUserId(string userId)
        {
            return _database.AspNetUserLogins.Where(x => x.UserId == userId)
                .Select(x => new UserLoginInfo(x.LoginProvider, x.ProviderKey)).ToList<UserLoginInfo>();
        }
    }
}
