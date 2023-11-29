CREATE DATABASE redbrowdb;
GO
USE redbrowdb;

Create table [User]
(
   Id  uniqueidentifier primary key,
   Name varchar(100),
   Email varchar(100),
   Age int,
   Nationality varchar(100),
   Created datetime,
   CreatedBy varchar(100) null,
   LastModified datetime null,
   LastModifiedBy varchar(100) null,
   RowVersion  uniqueidentifier
)

INSERT INTO [User] (Id,Name, Email, Age, Nationality, Created, CreatedBy)
values ('553e2e51-cf4d-4923-b2e9-e97575cf7a68', 'Gustavo Moreno', 'gustavoamoreno@outlook.com',36, 'Colombiana',GETDATE(), 'Administrador');