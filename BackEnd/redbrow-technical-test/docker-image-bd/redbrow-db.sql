CREATE DATABASE redbrowdb;
GO
USE redbrowdb;

Create table [User]
(
   Id  uniqueidentifier primary key not null,
   Name varchar(100) not null,
   Email varchar(100) not null,
   Age int not null,
   Nationality varchar(100) not null,
   Created datetime not null,
   CreatedBy varchar(100) null,
   LastModified datetime null,
   LastModifiedBy varchar(100) null,
   RowVersion  uniqueidentifier not null
)

INSERT INTO [User] (Id,Name, Email, Age, Nationality, Created, CreatedBy, RowVersion)
values ('553e2e51-cf4d-4923-b2e9-e97575cf7a68', 'Gustavo Moreno', 'gustavoamoreno@outlook.com',36, 'Colombiana',GETDATE(), 'Administrador', 'a8871de5-976b-48bc-b5dc-6c8f288bfd48');