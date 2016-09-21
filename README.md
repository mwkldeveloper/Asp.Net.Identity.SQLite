# AspNet.Identity.SQLite
AspNet Identity SQLite Provider

This is SQLite Provider for Asp.net Identity which is creadted following Microsoft's guide below:

Overview of Custom Storage Providers for ASP.NET Identity
http://www.asp.net/identity/overview/extensibility/overview-of-custom-storage-providers-for-aspnet-identity


Uasge:

1. git clone the repository
2. open with visual studio (this project created with visual studio 2015)
3. build the source
4. Create a sqlite DB and create table using
[SQLiteIdentity.sql](https://github.com/leung85/AspNet.Identity.SQLite/blob/master/AspNet.Identity.SQLite/SQLiteIdentity.sql) (included this project)
5. Create a new MVC project includes Individual User Accounts 
6. Remove Microsoft.AspNet.Identity.EntityFramework using Manage NuGet Packages. 
7.  replace all references to
        ```using Microsoft.AspNet.Identity.EntityFramework; ```
    with
        ```using AspNet.Identity.SQLite; ```
8. Add this project reference (AspNet.Identity.SQLite.dll) to the MVC project
9. set ApplicationDbContext to derive from SQLiteDatabase: 
    ```
        public class ApplicationDbContext : SQLiteDatabase
        {
            public ApplicationDbContext(string connectionName)
                : base(connectionName)
            {
            }
        
            public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext("DefaultConnection");
            }
        }
     ```
10.  Open the IdentityConfig.cs file. In the ApplicationUserManager.Create method, replace instantiating UserManager with the following code:
  ```
        var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>() as SQLiteDatabase));
  ```
11. replace the DefaultConnection with your connection string in web.config
12. Test it and have fun


# Usage Refrence:

Implementing a Custom MySQL ASP.NET Identity Storage Provide
http://www.asp.net/identity/overview/extensibility/implementing-a-custom-mysql-aspnet-identity-storage-provider
