namespace AspNet.Identity.SQLite.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using global::SQLite.CodeFirst;

    public partial class SQLiteIdenitityDbContext : DbContext
    {
        public SQLiteIdenitityDbContext()
            : base("name=SQLiteIdenitityDbContext")
        {
        }

        public SQLiteIdenitityDbContext(string connectionString)
          : base(connectionString)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<AspNetRole>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<AspNetUserClaim>()
                .Property(e => e.ClaimType)
                .IsUnicode(false);

            modelBuilder.Entity<AspNetUserClaim>()
                .Property(e => e.ClaimValue)
                .IsUnicode(false);

            modelBuilder.Entity<AspNetUserClaim>()
                .Property(e => e.UserId)
                .IsUnicode(false);

            modelBuilder.Entity<AspNetUserLogin>()
                .Property(e => e.UserId)
                .IsUnicode(false);

            modelBuilder.Entity<AspNetUserLogin>()
                .Property(e => e.LoginProvider)
                .IsUnicode(false);

            modelBuilder.Entity<AspNetUserLogin>()
                .Property(e => e.ProviderKey)
                .IsUnicode(false);

            modelBuilder.Entity<AspNetUser>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<AspNetUser>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<AspNetUser>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetRoles)
                .WithMany(e => e.AspNetUsers)
                .Map(m => m.ToTable("AspNetUserRole").MapLeftKey("UserId").MapRightKey("RoleId"));

        }
    }
}
