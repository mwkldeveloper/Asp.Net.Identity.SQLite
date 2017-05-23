using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet.Identity.SQLite
{
    /// <summary>
    /// Class that implements the key ASP.NET Identity role store iterfaces
    /// </summary>
    public class RoleStore<TRole> : IQueryableRoleStore<TRole>
        where TRole : IdentityRole
    {
        private RoleTable<TRole> roleTable;
        public SQLiteDatabase Database { get; private set; }
		private bool DisposeContext;
		public IQueryable<TRole> Roles
        {
            get
            {
                return roleTable.GetRoles().AsQueryable<TRole>();
               // throw new NotImplementedException();
            }
        }


        /// <summary>
        /// Default constructor that initializes a new SQLiteDatabase
        /// instance using the Default Connection string
        /// </summary>
        public RoleStore()
        {
			DisposeContext = true;
			new RoleStore<TRole>(new SQLiteDatabase());
        }

        /// <summary>
        /// Constructor that takes a SQLiteDatabase as argument 
        /// </summary>
        /// <param name="database"></param>
        public RoleStore(SQLiteDatabase database)
        {
			DisposeContext = false;
			Database = database;
            roleTable = new RoleTable<TRole>(database);
        }

        public Task CreateAsync(TRole role)
        {
            if (role == null)
            {
                throw new ArgumentNullException("role");
            }

            roleTable.Insert(role);

            return Task.FromResult<object>(null);
        }

        public Task DeleteAsync(TRole role)
        {
            if (role == null)
            {
                throw new ArgumentNullException("user");
            }

            roleTable.Delete(role.Id);

            return Task.FromResult<Object>(null);
        }

        public Task<TRole> FindByIdAsync(string roleId)
        {
            TRole result = roleTable.GetRoleById(roleId) as TRole;

            return Task.FromResult<TRole>(result);
        }

        public Task<TRole> FindByNameAsync(string roleName)
        {
            TRole result = roleTable.GetRoleByName(roleName) as TRole;

            return Task.FromResult<TRole>(result);
        }

        public Task UpdateAsync(TRole role)
        {
            if (role == null)
            {
                throw new ArgumentNullException("user");
            }

            roleTable.Update(role);

            return Task.FromResult<Object>(null);
        }

        public void Dispose()
        {
            if (Database != null)
            {
				if (DisposeContext)
				{
					Database.Dispose();
					Database = null;
				}
            }
        }

    }
}
