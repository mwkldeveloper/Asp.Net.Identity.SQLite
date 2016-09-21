
CREATE TABLE IF NOT EXISTS 'AspNetRoles' ( 
  Id varchar(128) NOT NULL,
  Name varchar(256) NOT NULL,
  PRIMARY KEY (Id)
);

CREATE TABLE IF NOT EXISTS 'AspNetUsers' (
 Id varchar (128) NOT NULL,
 Email varchar (256) DEFAULT NULL,
 EmailConfirmed tinyint (1) NOT NULL,
 PasswordHash longtext,
 SecurityStamp longtext,
 PhoneNumber longtext,
 PhoneNumberConfirmed tinyint (1) NOT NULL,
 TwoFactorEnabled tinyint (1) NOT NULL,
 LockoutEndDateUtc datetime DEFAULT NULL,
 LockoutEnabled tinyint (1) NOT NULL,
 AccessFailedCount int (11) NOT NULL,
 UserName varchar (256) NOT NULL,
 IsActivated tinyint(1) NOT NULL DEFAULT (0),
 PRIMARY KEY (Id));

CREATE TABLE IF NOT EXISTS 'AspNetUserClaims' ( 
  Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
  ClaimType varchar(256) NULL,
  ClaimValue varchar(256) NULL,
  UserId varchar(128) NOT NULL,
  FOREIGN KEY (UserId) REFERENCES AspNetUsers (Id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS 'AspNetUserLogins' ( 
  UserId varchar(128) NOT NULL,
  LoginProvider varchar(128) NOT NULL,
  ProviderKey varchar(128) NOT NULL,
  PRIMARY KEY (UserId, LoginProvider, ProviderKey),
  FOREIGN KEY (UserId) REFERENCES AspNetUsers (Id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS 'AspNetUserRoles' ( 
  UserId varchar(128) NOT NULL,
  RoleId varchar(128) NOT NULL,
  PRIMARY KEY (UserId, RoleId),
  FOREIGN KEY (RoleId) REFERENCES AspNetRoles (Id) ON DELETE CASCADE,
  FOREIGN KEY (UserId) REFERENCES AspNetUsers (Id) ON DELETE CASCADE
);

CREATE INDEX IX_AspNetUserClaims_UserId ON AspNetUserClaims (UserId);

CREATE INDEX IX_AspNetUserLogins_UserId ON AspNetUserLogins (UserId);

CREATE INDEX IX_AspNetUserRoles_RoleId ON AspNetUserRoles (RoleId);

CREATE INDEX IX_AspNetUserRoles_UserId ON AspNetUserRoles (UserId);