using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNet.Identity.SQLite.EF
{
    /// <summary>
    /// Class that represents the Role table in the SQLite Database
    /// </summary>
    public class RoleTable<TRole> where TRole : IdentityRole
    {
        private SQLiteIdenitityDbContext _database;

        /// <summary>
        /// Constructor that takes a SQLiteIdenitityDbContext instance 
        /// </summary>
        /// <param name="database"></param>
        public RoleTable(SQLiteIdenitityDbContext database)
        {
            _database = database;
        }

        /// <summary>
        /// Deltes a role from the AspNetRoles table
        /// </summary>
        /// <param name="roleId">The role Id</param>
        /// <returns></returns>
        public int Delete(string roleId)
        {
            var role = _database.AspNetRoles.Find(roleId);
            _database.AspNetRoles.Remove(role);
            return _database.SaveChanges();
        }

        /// <summary>
        /// Inserts a new Role in the AspNetRoles table
        /// </summary>
        /// <param name="roleName">The role's name</param>
        /// <returns></returns>
        public int Insert(IdentityRole role)
        {

            AspNetRole newRole = new AspNetRole();
            newRole.Name = role.Name;
            newRole.Id = role.Id;
            _database.AspNetRoles.Add(newRole);
            return _database.SaveChanges();
        }

        /// <summary>
        /// Returns a role name given the roleId
        /// </summary>
        /// <param name="roleId">The role Id</param>
        /// <returns>Role name</returns>
        public string GetRoleName(string roleId)
        {

            return _database.AspNetRoles.Find(roleId).Name;
        }

        /// <summary>
        /// Returns the role Id given a role name
        /// </summary>
        /// <param name="roleName">Role's name</param>
        /// <returns>Role's Id</returns>
        public string GetRoleId(string roleName)
        {
            return _database.AspNetRoles.SingleOrDefault(r=>r.Name==roleName).Id;
        }

        /// <summary>
        /// Gets the IdentityRole given the role Id
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public IdentityRole GetRoleById(string roleId)
        {
            return _database.AspNetRoles.Where(x=>x.Id == roleId)
                .Select(x=> new IdentityRole(x.Name, x.Id))
                .SingleOrDefault();
        }

        public List<TRole> GetRoles()
        {
            List<TRole> rolelist = new List<TRole>();
            var rows = _database.AspNetRoles;
            foreach (var row in rows)
            {
                TRole role = null;
                role = (TRole)Activator.CreateInstance(typeof(TRole));
                role.Id = row.Id;
                role.Name = row.Name;
                rolelist.Add(role);
            }
            return rolelist;
        }

        /// <summary>
        /// Gets the IdentityRole given the role name
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public IdentityRole GetRoleByName(string roleName)
        {
            var roleId = GetRoleId(roleName);
            IdentityRole role = null;

            if (roleId != null)
            {
                role = new IdentityRole(roleName, roleId);
            }

            return role;
        }

        public int Update(IdentityRole idrole)
        {
            var role = _database.AspNetRoles.Find(idrole.Id);
            role.Name = idrole.Name;
            return _database.SaveChanges();
        }
    }
}
