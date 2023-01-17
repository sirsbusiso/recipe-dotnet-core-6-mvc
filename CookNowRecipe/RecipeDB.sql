
CREATE DATABASE RecipeDB
GO

USE RecipeDB
GO

CREATE TABLE tb_Role(
[RoleId] int primary key identity(1,1),
[RoleName] varchar(50) not null
)

CREATE TABLE tb_User
(
[UserId] int primary key identity(1,1),
[RoleId] int foreign key references tb_Role([RoleId]),
[UserName] varchar(50) not null,
[FirstName] varchar(50) not null,
[LastName] varchar(50) not null,
[Password] varchar(50) not null
)

CREATE TABLE tb_Recipe
(
 [RecId] int primary key identity(1,1),
 [UserId] int foreign key references tb_User([UserId]),
 [RecipeName] varchar(50) not null,
 [Ingredient] varchar(max) null,
 [Instructions] xml null,
 [DateCreated] datetime not null
)

CREATE TABLE tb_Recipe_Image
( 
  [ImageId] int primary key identity(1,1),
  [RecId] int foreign key references tb_Recipe([RecId]),
  [FileName] varchar(255) null,
  [FilePath] varchar(255) not null,
  [FileType] varchar(255) null
)

INSERT INTO tb_Role(RoleName) VALUES('Admin');
INSERT INTO tb_Role(RoleName) VALUES('User');

INSERT INTO tb_User(RoleId, UserName, FirstName, LastName, Password) VALUES(1,'admin@cooknowrecipe.co.za', 'John', 'Smith', 'Johns123');
