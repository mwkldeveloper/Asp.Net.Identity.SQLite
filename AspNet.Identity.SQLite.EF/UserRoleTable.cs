using System.Collections.Generic;
using System.Linq;

namespace AspNet.Identity.SQLite.EF
{
    /// <summary>
    /// Class that represents the AspNetUserRoles table in the SQLite Database
    /// </summary>
    public class UserRolesTable
    {
        private SQLiteIdenitityDbContext _database;

        /// <summary>
        /// Constructor that takes a SQLiteIdenitityDbContext instance 
        /// </summary>
        /// <param name="database"></param>
        public UserRolesTable(SQLiteIdenitityDbContext database)
        {
            _database = database;
        }

        /// <summary>
        /// Returns a list of user's roles
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// <returns></returns>
        public List<string> FindByUserId(string userId)
        {
            return _database.AspNetUsers.Where(x => x.Id == userId).SelectMany(x => x.AspNetRoles).Select(x => x.Name).ToList();
        }

        /// <summary>
        /// Deletes all roles from a user in the AspNetUserRoles table
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// <returns></returns>
        public int Delete(string userId)
        {
            var userRoles = _database.AspNetUserRoles.Where(x => x.UserId == userId);
             _database.AspNetUserRoles.RemoveRange(userRoles);
            return _database.SaveChanges();
        }

        /// <summary>
        /// Inserts a new role for a user in the AspNetUserRoles table
        /// </summary>
        /// <param name="user">The User</param>
        /// <param name="roleId">The Role's id</param>
        /// <returns></returns>
        public int Insert(IdentityUser user, string roleId)
        {

            AspNetUserRoles userRole = new AspNetUserRoles();
            userRole.UserId = user.Id;
            userRole.RoleId = roleId;
            _database.AspNetUserRoles.Add(userRole);
            return _database.SaveChanges();
        }
    }
}
