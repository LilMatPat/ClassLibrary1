USE [master]
GO
/****** Object:  Database [Tilt]    Script Date: 9/11/2019 3:39:48 PM ******/
CREATE DATABASE [Tilt]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Tilt', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Tilt.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Tilt_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Tilt_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Tilt] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Tilt].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Tilt] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Tilt] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Tilt] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Tilt] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Tilt] SET ARITHABORT OFF 
GO
ALTER DATABASE [Tilt] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Tilt] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Tilt] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Tilt] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Tilt] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Tilt] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Tilt] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Tilt] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Tilt] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Tilt] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Tilt] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Tilt] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Tilt] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Tilt] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Tilt] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Tilt] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Tilt] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Tilt] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Tilt] SET  MULTI_USER 
GO
ALTER DATABASE [Tilt] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Tilt] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Tilt] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Tilt] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Tilt] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Tilt] SET QUERY_STORE = OFF
GO
USE [Tilt]
GO
/****** Object:  Table [dbo].[Knights]    Script Date: 9/11/2019 3:39:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Knights](
	[KnightID] [int] IDENTITY(1,1) NOT NULL,
	[KnightName] [nvarchar](25) NULL,
	[Strength] [int] NULL,
	[Dexterity] [int] NULL,
	[Precision] [int] NULL,
	[Constitution] [int] NULL,
	[UserID] [int] NULL,
	[OrderID] [int] NULL,
 CONSTRAINT [PK_Knights] PRIMARY KEY CLUSTERED 
(
	[KnightID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Logger]    Script Date: 9/11/2019 3:39:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logger](
	[LogID] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NULL,
	[StackTrace] [nvarchar](max) NULL,
 CONSTRAINT [PK_Logger] PRIMARY KEY CLUSTERED 
(
	[LogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 9/11/2019 3:39:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[OrderName] [nvarchar](250) NULL,
	[OrderBonus] [nvarchar](50) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 9/11/2019 3:39:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 9/11/2019 3:39:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NULL,
	[EmailAddress] [nvarchar](250) NULL,
	[Password] [nvarchar](50) NULL,
	[Hash] [nvarchar](50) NULL,
	[RoleID] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Knights] ON 

INSERT [dbo].[Knights] ([KnightID], [KnightName], [Strength], [Dexterity], [Precision], [Constitution], [UserID], [OrderID]) VALUES (1, N'Sir Phillips', 70, 37, 63, 31, 6, 2)
INSERT [dbo].[Knights] ([KnightID], [KnightName], [Strength], [Dexterity], [Precision], [Constitution], [UserID], [OrderID]) VALUES (5, N'SaladManAngry', 79, 29, 33, 23, 10, 1)
INSERT [dbo].[Knights] ([KnightID], [KnightName], [Strength], [Dexterity], [Precision], [Constitution], [UserID], [OrderID]) VALUES (15, N'Leonis', 55, 55, 55, 55, 7, 2)
INSERT [dbo].[Knights] ([KnightID], [KnightName], [Strength], [Dexterity], [Precision], [Constitution], [UserID], [OrderID]) VALUES (19, N'ProteinShake', 66, 22, 22, 66, 27, 2)
SET IDENTITY_INSERT [dbo].[Knights] OFF
SET IDENTITY_INSERT [dbo].[Logger] ON 

INSERT [dbo].[Logger] ([LogID], [Message], [StackTrace]) VALUES (1, N'The number of rows provided for a FETCH clause must be greater then zero.', N'   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   at System.Data.SqlClient.SqlDataReader.TryHasMoreRows(Boolean& moreRows)
   at System.Data.SqlClient.SqlDataReader.TryReadInternal(Boolean setTimeout, Boolean& more)
   at System.Data.SqlClient.SqlDataReader.Read()
   at DataAccessLayer.ContextDAL.GetKnightsRelatedToUser(Int32 skip, Int32 take, Int32 UserID) in C:\Users\Onshore\source\repos\ClassLibrary1\ClassLibrary1\ContextDAL.cs:line 577
   at BLL.ContextBLL.GetKnightsRelatedToUser(Int32 UserID, Int32 skip, Int32 take) in C:\Users\Onshore\source\repos\ClassLibrary1\BLL\ContextBLL.cs:line 321
   at TiltWebsite.Controllers.JoustController.Challenge(Int32 id) in C:\Users\Onshore\source\repos\ClassLibrary1\TiltWebsite\Controllers\JoustController.cs:line 63')
INSERT [dbo].[Logger] ([LogID], [Message], [StackTrace]) VALUES (2, N'Index was out of range. Must be non-negative and less than the size of the collection.
Parameter name: index', N'   at System.ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument argument, ExceptionResource resource)
   at System.Collections.Generic.List`1.get_Item(Int32 index)
   at TiltWebsite.Controllers.JoustController.Challenge(Int32 id) in C:\Users\Onshore\source\repos\ClassLibrary1\TiltWebsite\Controllers\JoustController.cs:line 64')
INSERT [dbo].[Logger] ([LogID], [Message], [StackTrace]) VALUES (3, N'Index was out of range. Must be non-negative and less than the size of the collection.
Parameter name: index', N'   at System.ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument argument, ExceptionResource resource)
   at System.Collections.Generic.List`1.get_Item(Int32 index)
   at TiltWebsite.Controllers.JoustController.Challenge(Int32 id) in C:\Users\Onshore\source\repos\ClassLibrary1\TiltWebsite\Controllers\JoustController.cs:line 64')
SET IDENTITY_INSERT [dbo].[Logger] OFF
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([OrderID], [OrderName], [OrderBonus]) VALUES (1, N'The Radiant Dawn', N'+2 to Constitution, +2 to Dexterity')
INSERT [dbo].[Orders] ([OrderID], [OrderName], [OrderBonus]) VALUES (2, N'Tyrants of Draconis', N'+2  to Strength, +2 to Precision')
SET IDENTITY_INSERT [dbo].[Orders] OFF
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (5, N'Knight')
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (6, N'Lord')
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (7, N'King')
SET IDENTITY_INSERT [dbo].[Roles] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [Username], [EmailAddress], [Password], [Hash], [RoleID]) VALUES (6, N'JesseA7X', N'Jesse@gmail.com', N'asdf12345', N'asdf12345', 6)
INSERT [dbo].[Users] ([UserID], [Username], [EmailAddress], [Password], [Hash], [RoleID]) VALUES (7, N'LilMatPat', N'LilMatPat@gmail.com', N'asdf12345', N'asdf12345', 7)
INSERT [dbo].[Users] ([UserID], [Username], [EmailAddress], [Password], [Hash], [RoleID]) VALUES (9, N'Cardoor', N'epicgamer68@gmail.com', N'epicgamer68', N'asdf12345', 6)
INSERT [dbo].[Users] ([UserID], [Username], [EmailAddress], [Password], [Hash], [RoleID]) VALUES (10, N'LordSalad', N'Kale@hotmail.com', N'punishthepatriots', N'asdf12345', 5)
INSERT [dbo].[Users] ([UserID], [Username], [EmailAddress], [Password], [Hash], [RoleID]) VALUES (27, N'MuscleMan', N'Muscle@gmail.com', N'asdf12345', N'AKvYNfRUYSaV7Lu/rDfzbOfAGtRM2/1r7QJXVynuwAJLtyGB3Q', 5)
INSERT [dbo].[Users] ([UserID], [Username], [EmailAddress], [Password], [Hash], [RoleID]) VALUES (30, N'Derplock', N'Guerrero@email.com', N'asdf12345', N'AHaGIzA+bnT5pKKGxmuZFRMKwtRc6230uUml5RxAtgHmb5cejd', 5)
INSERT [dbo].[Users] ([UserID], [Username], [EmailAddress], [Password], [Hash], [RoleID]) VALUES (33, N'Regist', N'johnnyquest@mail.com', N'asdf12345', N'asdf12345', 5)
INSERT [dbo].[Users] ([UserID], [Username], [EmailAddress], [Password], [Hash], [RoleID]) VALUES (34, N'Cardoor', N'StoneyBaloney@gmail.com', N'asdf12345', N'asdf12345', 5)
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Knights]  WITH CHECK ADD  CONSTRAINT [FK_Knights_Orders] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
ALTER TABLE [dbo].[Knights] CHECK CONSTRAINT [FK_Knights_Orders]
GO
ALTER TABLE [dbo].[Knights]  WITH CHECK ADD  CONSTRAINT [FK_Knights_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Knights] CHECK CONSTRAINT [FK_Knights_Users]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
/****** Object:  StoredProcedure [dbo].[CreateKnight]    Script Date: 9/11/2019 3:39:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateKnight]
	-- Add the parameters for the stored procedure here
	@KnightID int output,
	@KnightName nvarchar(25),
	@Strength int,
	@Dexterity int,
	@Precision int,
	@Constitution int,
	@UserID int,
	@OrderID int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into Knights
	(KnightName,Strength,Dexterity,Precision,Constitution,UserID,OrderID)
	VALUES
	(@KnightName,@Strength,@Dexterity,@Precision,@Constitution, @UserID,@OrderID)
	select @KnightID = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[CreateOrder]    Script Date: 9/11/2019 3:39:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateOrder]
	-- Add the parameters for the stored procedure here
	@OrderID int output,
	@OrderName nvarchar(250),
	@OrderBonus nvarchar(50)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into Orders
	(OrderName,OrderBonus)
	VALUES
	(@OrderName,@OrderBonus)
	select @OrderID = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[CreateRole]    Script Date: 9/11/2019 3:39:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateRole]
	-- Add the parameters for the stored procedure here
	@RoleID int output,

	@RoleName nvarchar(50)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into Roles
	(RoleName)
	VALUES
	(@RoleName)
	select @RoleID = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[CreateUser]    Script Date: 9/11/2019 3:39:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateUser]
	-- Add the parameters for the stored procedure here
	@UserID int output,
	@Username nvarchar(50),
	@EmailAddress nvarchar(250),
	@Password nvarchar(50),
	@Hash nvarchar(50),
	@RoleID int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into Users
	(Username,EmailAddress,Password,Hash,RoleID)
	VALUES
	(@Username,@EmailAddress,@Password,@Hash,@RoleID)
	select @UserID = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteKnight]    Script Date: 9/11/2019 3:39:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteKnight]
	-- Add the parameters for the stored procedure here
	@KnightID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete from Knights where @KnightID=KnightID
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteOrder]    Script Date: 9/11/2019 3:39:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteOrder]
	-- Add the parameters for the stored procedure here
	@OrderID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete from Knights where OrderID=@OrderID
	delete from Orders where OrderID=@OrderID
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteRole]    Script Date: 9/11/2019 3:39:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteRole]
	-- Add the parameters for the stored procedure here
	@RoleID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete from Roles where RoleID=@RoleID
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 9/11/2019 3:39:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteUser]
	-- Add the parameters for the stored procedure here
	@UserID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete from Knights where UserID=@UserID
	delete from Users where @UserID=UserID
END
GO
/****** Object:  StoredProcedure [dbo].[FindKnightByID]    Script Date: 9/11/2019 3:39:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[FindKnightByID]
	-- Add the parameters for the stored procedure here
	@KnightID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select KnightID,KnightName, Strength, Dexterity, Constitution, Precision , Knights.OrderID  , Knights.UserID
	from Knights
	inner join Users on Users.UserID = Knights.UserID
	inner join Orders on Orders.OrderID = Knights.OrderID
	where KnightID=@KnightID
END
GO
/****** Object:  StoredProcedure [dbo].[FindOrderByID]    Script Date: 9/11/2019 3:39:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[FindOrderByID]
	-- Add the parameters for the stored procedure here
	@OrderID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select OrderID,OrderName, OrderBonus
	from Orders
	where OrderID=@OrderID
END
GO
/****** Object:  StoredProcedure [dbo].[FindRoleByID]    Script Date: 9/11/2019 3:39:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[FindRoleByID]
	-- Add the parameters for the stored procedure here
	@RoleID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select RoleID,RoleName
	from Roles
	where RoleID=@RoleID 
	
END
GO
/****** Object:  StoredProcedure [dbo].[FindUserByEmailAddress]    Script Date: 9/11/2019 3:39:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[FindUserByEmailAddress]
	-- Add the parameters for the stored procedure here
	@EmailAddress nvarchar (250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select UserID,Username,EmailAddress,Password,Hash,Users.RoleID
	from Users
	inner join Roles on Users.RoleID =Roles.RoleID
	Where EmailAddress = @EmailAddress
END
GO
/****** Object:  StoredProcedure [dbo].[FindUserByID]    Script Date: 9/11/2019 3:39:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[FindUserByID]
	-- Add the parameters for the stored procedure here
	@UserID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select UserID,Username,EmailAddress, Password, Hash, Users.RoleID, RoleName
	
	From Users 
	inner join Roles on roles.RoleID =Users.RoleID
	Where UserID =@UserID
END
GO
/****** Object:  StoredProcedure [dbo].[FindUserByUsername]    Script Date: 9/11/2019 3:39:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[FindUserByUsername]
	-- Add the parameters for the stored procedure here
	@Username nvarchar (50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select UserID,Username,EmailAddress,Password,Hash,Users.RoleID
	from Users
	inner join Roles on Users.RoleID =Roles.RoleID
	Where Username = @Username
END
GO
/****** Object:  StoredProcedure [dbo].[GetKnights]    Script Date: 9/11/2019 3:39:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetKnights] 
	-- Add the parameters for the stored procedure here
	@skip int,
	@take int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select KnightID,KnightName,Strength,Dexterity,  Constitution, Precision, Knights.OrderID, Knights.UserID
	From Knights 
	inner join Users on Users.UserID = Knights.UserID
	inner join Orders on Orders.OrderID = Knights.OrderID
	order by KnightID OFFSET @skip rows fetch next @take rows only;
END
GO
/****** Object:  StoredProcedure [dbo].[GetKnightsRelatedtoOrder]    Script Date: 9/11/2019 3:39:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[GetKnightsRelatedtoOrder] 
	-- Add the parameters for the stored procedure here
	@OrderID int,
	@skip int,
	@take int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select KnightID,KnightName, Strength, Constitution,Dexterity,Precision, Knights.UserID, Knights.OrderID
	From Knights
	inner join Users on Users.UserID= Knights.UserID
	inner join Orders on Orders.OrderId = Knights.UserID
	where Knights.OrderID =@OrderID
	order by UserID OFFSET @skip rows fetch next @take rows only;

	
END
GO
/****** Object:  StoredProcedure [dbo].[GetKnightsRelatedtoUser]    Script Date: 9/11/2019 3:39:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetKnightsRelatedtoUser] 
	-- Add the parameters for the stored procedure here
	@UserID int,
	@skip int,
	@take int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select KnightID,KnightName, Strength, Dexterity,Constitution,Precision,Knights.OrderID, Knights.UserID 
	From Knights
	inner join Users on Users.UserID= Knights.UserID
	inner join Orders on Orders.OrderID = Knights.OrderID
	where Knights.UserID =@UserID
	order by UserID OFFSET @skip rows fetch next @take rows only;

	
END
GO
/****** Object:  StoredProcedure [dbo].[GetOrders]    Script Date: 9/11/2019 3:39:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetOrders] 
	-- Add the parameters for the stored procedure here
	@skip int,
	@take int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select OrderID, OrderName, OrderBonus
	From Orders order by OrderID OFFSET @skip rows fetch next @take rows only;
	
END
GO
/****** Object:  StoredProcedure [dbo].[GetRoles]    Script Date: 9/11/2019 3:39:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetRoles] 
	-- Add the parameters for the stored procedure here
	@skip int,
	@take int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select RoleID,RoleName
	From Roles
	
END
GO
/****** Object:  StoredProcedure [dbo].[GetUsers]    Script Date: 9/11/2019 3:39:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetUsers] 
	-- Add the parameters for the stored procedure here
	@skip int,
	@take int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select UserID,Username,EmailAddress, Password, Hash, Users.RoleID, RoleName
	
	From Users 
	inner join Roles on roles.RoleID =Users.RoleID
	order by UserID OFFSET @skip rows fetch next @take rows only;

	
END
GO
/****** Object:  StoredProcedure [dbo].[GetUsersRelatedtoRole]    Script Date: 9/11/2019 3:39:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetUsersRelatedtoRole] 
	-- Add the parameters for the stored procedure here
	@RoleID int,
	@skip int,
	@take int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select UserID,Username,EmailAddress, Password, Hash, Users.RoleID
	From Users 
	inner join Roles on Roles.RoleID = Users.RoleID 
	where Users.RoleID =@RoleID
	order by UserID OFFSET @skip rows fetch next @take rows only;

	
END
GO
/****** Object:  StoredProcedure [dbo].[InsertLogItem]    Script Date: 9/11/2019 3:39:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertLogItem] 
	-- Add the parameters for the stored procedure here
	
	@Message nvarchar(max),
	@StackTrace nvarchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into dbo.Logger (Message,StackTrace)
	Values
	(@Message,@StackTrace)
	
END
GO
/****** Object:  StoredProcedure [dbo].[JustUpdateKnight]    Script Date: 9/11/2019 3:39:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[JustUpdateKnight]
	-- Add the parameters for the stored procedure here
	@KnightID int,
	@KnightName nvarchar(25),
	@Strength int,
	@Dexterity int,
	@Precision int,
	@Constitution int,
	@UserID int,
	@OrderID int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update Knights set  KnightName=@KnightName, Strength=@Strength,Dexterity=@Dexterity, 
	Precision=@Precision, Constitution=@Constitution,UserId=@UserID, OrderID=@OrderID
	where KnightID=@KnightID
END
GO
/****** Object:  StoredProcedure [dbo].[JustUpdateOrder]    Script Date: 9/11/2019 3:39:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[JustUpdateOrder]
	-- Add the parameters for the stored procedure here
	@OrderID int,
	@OrderName nvarchar(250),
	@OrderBonus nvarchar(50)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update Orders set  OrderName=@OrderName, OrderBonus=@OrderBonus
	where OrderID=@OrderID
END
GO
/****** Object:  StoredProcedure [dbo].[JustUpdateRole]    Script Date: 9/11/2019 3:39:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[JustUpdateRole]
	-- Add the parameters for the stored procedure here
	@RoleID int,
	@RoleName nvarchar(50)
	

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update Roles set  RoleName=@RoleName
	where RoleID=@RoleID
END
GO
/****** Object:  StoredProcedure [dbo].[JustUpdateUser]    Script Date: 9/11/2019 3:39:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[JustUpdateUser]
	-- Add the parameters for the stored procedure here
	@UserID int,
	@Username nvarchar(50),
	@EmailAddress nvarchar(50),
	@Password nvarchar(50),
	@Hash nvarchar(50),
	@RoleID int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update Users set  Username = @Username, EmailAddress =@EmailAddress, Password =@Password,Hash=@Hash, RoleID=@RoleID
	where UserID=@UserID
END
GO
/****** Object:  StoredProcedure [dbo].[ObtainKnightCount]    Script Date: 9/11/2019 3:39:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ObtainKnightCount]

as
begin
select count(*) from Knights



end
GO
/****** Object:  StoredProcedure [dbo].[ObtainOrderCount]    Script Date: 9/11/2019 3:39:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ObtainOrderCount]

as
begin
select count(*) from Orders



end
GO
/****** Object:  StoredProcedure [dbo].[ObtainRoleCount]    Script Date: 9/11/2019 3:39:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ObtainRoleCount]

as
begin
select count(*) from Roles



end
GO
/****** Object:  StoredProcedure [dbo].[ObtainUserCount]    Script Date: 9/11/2019 3:39:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ObtainUserCount]

as
begin
select count(*) from Users



end
GO
/****** Object:  StoredProcedure [dbo].[SafeUpdateKnight]    Script Date: 9/11/2019 3:39:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SafeUpdateKnight]
	-- Add the parameters for the stored procedure here
	
	@KnightID int,
	@OldKnightName nvarchar(25),
	@NewKnightName nvarchar(25),
	@OldStrength int,
	@NewStrength int,
	@OldDexterity int,
	@NewDexterity int,
	@OldPrecision int,
	@NewPrecision int,
	@OldConstitution int,
	@NewConstitution int,
	@UserID int,
	@OrderID int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @rv int
	select @rv=count (*) from Knights
	where KnightID=@KnightID and KnightName=@OldKnightName and Strength=@OldStrength and Dexterity=@OldDexterity and 
	Precision=@OldPrecision and Constitution=@OldConstitution and UserId=@UserID and OrderID=@OrderID
	
	Update Knights set  KnightName=@NewKnightName, Strength=@NewStrength,Dexterity=@NewDexterity, 
	Precision=@NewPrecision, Constitution=@NewConstitution,UserId=@UserID, OrderID=@OrderID
	where KnightID=@KnightID and KnightName=@OldKnightName and Strength=@OldStrength and Dexterity=@OldDexterity and 
	Precision=@OldPrecision and Constitution=@OldConstitution and UserId=@UserID and OrderID=@OrderID
	return @rv
END
GO
USE [master]
GO
ALTER DATABASE [Tilt] SET  READ_WRITE 
GO
