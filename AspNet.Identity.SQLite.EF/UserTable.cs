
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNet.Identity.SQLite.EF
{
    /// <summary>
    /// Class that represents the AspNetUsers table in the MySQL Database
    /// </summary>
    public class UserTable<TUser>
        where TUser : IdentityUser
    {
        private SQLiteIdenitityDbContext _database;

        /// <summary>
        /// Constructor that takes a SQLiteIdenitityDbContext instance 
        /// </summary>
        /// <param name="database"></param>
        public UserTable(SQLiteIdenitityDbContext database)
        {
            _database = database;
        }




        /// <summary>
        /// Returns the user's name given a user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GetUserName(string userId)
        {
            return _database.AspNetUsers.Find(userId).UserName;
        }

        /// <summary>
        /// Returns a User ID given a user name
        /// </summary>
        /// <param name="userName">The user's name</param>
        /// <returns></returns>
        public string GetUserId(string userName)
        {
            return _database.AspNetUsers.Where(u => u.UserName == userName).Select(u => u.Id).SingleOrDefault();
        }

        /// <summary>
        /// Return all user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<TUser> GetUsers()
        {
            List<TUser> userlist = new List<TUser>();
            var rows = _database.AspNetUsers;
            foreach (var row in rows)
            {
                TUser user = null;
                user = (TUser)Activator.CreateInstance(typeof(TUser));

                user.Id = row.Id;
                user.UserName = row.UserName;
                user.PasswordHash = string.IsNullOrEmpty(row.PasswordHash) ? null : row.PasswordHash;
                user.SecurityStamp = string.IsNullOrEmpty(row.SecurityStamp) ? null : row.SecurityStamp;
                user.Email = string.IsNullOrEmpty(row.Email) ? null : row.Email;
                user.EmailConfirmed = row.EmailConfirmed.ToString() == "1" ? true : false;
                user.PhoneNumber = string.IsNullOrEmpty(row.PhoneNumber) ? null : row.PhoneNumber;
                user.PhoneNumberConfirmed = row.PhoneNumberConfirmed.ToString() == "1" ? true : false;
                user.LockoutEnabled = row.LockoutEnabled.ToString() == "1" ? true : false;
                user.LockoutEndDateUtc = string.IsNullOrEmpty(row.LockoutEndDateUtc.ToString()) ? DateTime.Now : row.LockoutEndDateUtc;
                user.AccessFailedCount = string.IsNullOrEmpty(row.AccessFailedCount.ToString()) ? 0 : row.AccessFailedCount;
                userlist.Add(user);
            }
            return userlist;

        }


        /// <summary>
        /// Returns an TUser given the user's id
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// <returns></returns>
        public TUser GetUserById(string userId)
        {
            var row = _database.AspNetUsers.Find(userId);

            TUser user = null;
            user = (TUser)Activator.CreateInstance(typeof(TUser));

            user.Id = row.Id;
            user.UserName = row.UserName;
            user.PasswordHash = string.IsNullOrEmpty(row.PasswordHash) ? null : row.PasswordHash;
            user.SecurityStamp = string.IsNullOrEmpty(row.SecurityStamp) ? null : row.SecurityStamp;
            user.Email = string.IsNullOrEmpty(row.Email) ? null : row.Email;
            user.EmailConfirmed = row.EmailConfirmed.ToString() == "1" ? true : false;
            user.PhoneNumber = string.IsNullOrEmpty(row.PhoneNumber) ? null : row.PhoneNumber;
            user.PhoneNumberConfirmed = row.PhoneNumberConfirmed.ToString() == "1" ? true : false;
            user.LockoutEnabled = row.LockoutEnabled.ToString() == "1" ? true : false;
            user.LockoutEndDateUtc = string.IsNullOrEmpty(row.LockoutEndDateUtc.ToString()) ? DateTime.Now : row.LockoutEndDateUtc;
            user.AccessFailedCount = string.IsNullOrEmpty(row.AccessFailedCount.ToString()) ? 0 : row.AccessFailedCount;


            return user;
        }

        /// <summary>
        /// Returns a list of TUser instances given a user name
        /// </summary>
        /// <param name="userName">User's name</param>
        /// <returns></returns>
        public List<TUser> GetUserByName(string userName)
        {
            List<TUser> users = new List<TUser>();
            var rows = _database.AspNetUsers.Where(u => u.UserName == userName);
            foreach (var row in rows)
            {
                TUser user = null;
                user = (TUser)Activator.CreateInstance(typeof(TUser));

                user.Id = row.Id;
                user.UserName = row.UserName;
                user.PasswordHash = string.IsNullOrEmpty(row.PasswordHash) ? null : row.PasswordHash;
                user.SecurityStamp = string.IsNullOrEmpty(row.SecurityStamp) ? null : row.SecurityStamp;
                user.Email = string.IsNullOrEmpty(row.Email) ? null : row.Email;
                user.EmailConfirmed = row.EmailConfirmed.ToString() == "1" ? true : false;
                user.PhoneNumber = string.IsNullOrEmpty(row.PhoneNumber) ? null : row.PhoneNumber;
                user.PhoneNumberConfirmed = row.PhoneNumberConfirmed.ToString() == "1" ? true : false;
                user.LockoutEnabled = row.LockoutEnabled.ToString() == "1" ? true : false;
                user.LockoutEndDateUtc = string.IsNullOrEmpty(row.LockoutEndDateUtc.ToString()) ? DateTime.Now : row.LockoutEndDateUtc;
                user.AccessFailedCount = string.IsNullOrEmpty(row.AccessFailedCount.ToString()) ? 0 : row.AccessFailedCount;
                users.Add(user);
            }

            return users;
        }

        public List<TUser> GetUserByEmail(string email)
        {
            List<TUser> users = new List<TUser>();
            var rows = _database.AspNetUsers.Where(u => u.Email == email);
            foreach (var row in rows)
            {
                TUser user = null;
                user = (TUser)Activator.CreateInstance(typeof(TUser));

                user.Id = row.Id;
                user.UserName = row.UserName;
                user.PasswordHash = string.IsNullOrEmpty(row.PasswordHash) ? null : row.PasswordHash;
                user.SecurityStamp = string.IsNullOrEmpty(row.SecurityStamp) ? null : row.SecurityStamp;
                user.Email = string.IsNullOrEmpty(row.Email) ? null : row.Email;
                user.EmailConfirmed = row.EmailConfirmed.ToString() == "1" ? true : false;
                user.PhoneNumber = string.IsNullOrEmpty(row.PhoneNumber) ? null : row.PhoneNumber;
                user.PhoneNumberConfirmed = row.PhoneNumberConfirmed.ToString() == "1" ? true : false;
                user.LockoutEnabled = row.LockoutEnabled.ToString() == "1" ? true : false;
                user.LockoutEndDateUtc = string.IsNullOrEmpty(row.LockoutEndDateUtc.ToString()) ? DateTime.Now : row.LockoutEndDateUtc;
                user.AccessFailedCount = string.IsNullOrEmpty(row.AccessFailedCount.ToString()) ? 0 : row.AccessFailedCount;
                users.Add(user);
            }

            return users;
        }

        /// <summary>
        /// Return the user's password hash
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// <returns></returns>
        public string GetPasswordHash(string userId)
        {
            return _database.AspNetUsers.Find(userId).PasswordHash;
        }

        /// <summary>
        /// Sets the user's password hash
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="passwordHash"></param>
        /// <returns></returns>
        public int SetPasswordHash(string userId, string passwordHash)
        {
            var newUser = _database.AspNetUsers.Find(userId);
            newUser.PasswordHash = passwordHash;

            return _database.SaveChanges();
        }

        /// <summary>
        /// Returns the user's security stamp
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GetSecurityStamp(string userId)
        {
            return _database.AspNetUsers.Find(userId).SecurityStamp;

        }

        /// <summary>
        /// Inserts a new user in the AspNetUsers table
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int Insert(TUser user)
        {

            AspNetUser newUser = new AspNetUser();
            newUser.UserName = user.UserName;
            newUser.Id = user.Id;
            newUser.PasswordHash = user.PasswordHash;
            newUser.SecurityStamp = user.SecurityStamp;
            newUser.Email = user.Email;
            newUser.EmailConfirmed = user.EmailConfirmed;
            newUser.PhoneNumber = user.PhoneNumber;
            newUser.PhoneNumberConfirmed = user.PhoneNumberConfirmed;
            newUser.AccessFailedCount = user.AccessFailedCount;
            newUser.LockoutEnabled = user.LockoutEnabled;
            newUser.LockoutEndDateUtc = user.LockoutEndDateUtc;
            newUser.TwoFactorEnabled = user.TwoFactorEnabled;
            _database.AspNetUsers.Add(newUser);

            return _database.SaveChanges();


        }

        /// <summary>
        /// Deletes a user from the AspNetUsers table
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// <returns></returns>
        private int Delete(string userId)
        {
            var user = _database.AspNetUsers.Find(userId);
            _database.AspNetUsers.Remove(user);
            return _database.SaveChanges();

        }

        /// <summary>
        /// Deletes a user from the AspNetUsers table
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int Delete(TUser user)
        {
            return Delete(user.Id);
        }

        /// <summary>
        /// Updates a user in the AspNetUsers table
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int Update(TUser user)
        {

            var newUser = _database.AspNetUsers.Find(user.Id);

            newUser.UserName = user.UserName;
            newUser.Id = user.Id;
            newUser.PasswordHash = user.PasswordHash;
            newUser.SecurityStamp = user.SecurityStamp;
            newUser.Email = user.Email;
            newUser.EmailConfirmed = user.EmailConfirmed;
            newUser.PhoneNumber = user.PhoneNumber;
            newUser.PhoneNumberConfirmed = user.PhoneNumberConfirmed;
            newUser.AccessFailedCount = user.AccessFailedCount;
            newUser.LockoutEnabled = user.LockoutEnabled;
            newUser.LockoutEndDateUtc = user.LockoutEndDateUtc;
            newUser.TwoFactorEnabled = user.TwoFactorEnabled;

            return _database.SaveChanges();

        }
    }
}
