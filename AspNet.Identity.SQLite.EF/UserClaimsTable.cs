using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace AspNet.Identity.SQLite.EF
{
    /// <summary>
    /// Class that represents the AspNetUserClaims table in the SQLite Database
    /// </summary>
    public class UserClaimsTable
    {
        private SQLiteIdenitityDbContext _database;

        /// <summary>
        /// Constructor that takes a SQLiteIdenitityDbContext instance 
        /// </summary>
        /// <param name="database"></param>
        public UserClaimsTable(SQLiteIdenitityDbContext database)
        {
            _database = database;
        }

        /// <summary>
        /// Returns a ClaimsIdentity instance given a userId
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// <returns></returns>
        public ClaimsIdentity FindByUserId(string userId)
        {
            ClaimsIdentity claims = new ClaimsIdentity();
            var claimsList = _database.AspNetUserClaims.Where(c => c.UserId == userId)
                .Select(x => new Claim(x.ClaimType, x.ClaimValue)).ToList();
            claims.AddClaims(claimsList);
            return claims;
        }

        /// <summary>
        /// Deletes all claims from a user given a userId
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// <returns></returns>
        public int Delete(string userId)
        {
            var userClaim = _database.AspNetUserClaims.Where(c => c.UserId == userId);
            _database.AspNetUserClaims.RemoveRange(userClaim);
            return _database.SaveChanges();
        }

        /// <summary>
        /// Inserts a new claim in AspNetUserClaims table
        /// </summary>
        /// <param name="userClaim">User's claim to be added</param>
        /// <param name="userId">User's id</param>
        /// <returns></returns>
        public int Insert(Claim userClaim, string userId)
        {

            AspNetUserClaim newUserClaim = new AspNetUserClaim();
            newUserClaim.ClaimValue = userClaim.Value;
            newUserClaim.ClaimType = userClaim.Type;
            newUserClaim.UserId = userId;
            _database.AspNetUserClaims.Add(newUserClaim);
            return _database.SaveChanges();
        }

        /// <summary>
        /// Deletes a claim from a user 
        /// </summary>
        /// <param name="user">The user to have a claim deleted</param>
        /// <param name="claim">A claim to be deleted from user</param>
        /// <returns></returns>
        public int Delete(IdentityUser user, Claim claim)
        {
            var userClaim = _database.AspNetUserClaims.Where(c => c.UserId == user.Id && c.ClaimValue == claim.Value && c.ClaimType == claim.Type);
            _database.AspNetUserClaims.RemoveRange(userClaim);
            return _database.SaveChanges();
        }
    }
}
