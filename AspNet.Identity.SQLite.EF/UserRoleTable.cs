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
            return _database.AspNetUsers.Where(x => x.Id == userId).SelectMany(x => x.AspNetRoles).Select(x => x.Name)?.ToList();
        }

        /// <summary>
        /// Deletes all roles from a user in the AspNetUserRoles table
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// <returns></returns>
        public int Delete(string userId)
        {
            var user = _database.AspNetUsers.Find(userId);
            var roles = user.AspNetRoles;
            foreach (var role in roles)
            {
                roles.Remove(role);
            }
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

            var role = _database.AspNetRoles.Find(roleId);
            _database.AspNetUsers.Find(user.Id).AspNetRoles.Add(role);
            return _database.SaveChanges();
        }
    }
}
