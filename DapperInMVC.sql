USE [DapperInMVC]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 7/29/2022 2:05:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  StoredProcedure [dbo].[AddNewEmpDetails]    Script Date: 7/29/2022 2:05:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AddNewEmpDetails]  
(  
   @Id int, 
   @Name varchar (50),  
   @City varchar (50),  
   @Address varchar (50)  
)  
as  
begin  
   Insert into Employee values(@Id,@Name,@City,@Address)  
End  
GO
/****** Object:  StoredProcedure [dbo].[DeleteEmpById]    Script Date: 7/29/2022 2:05:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[DeleteEmpById]  
(  
   @Id int  
)  
as  
begin  
   Delete from Employee where Id=@Id  
End  
GO
/****** Object:  StoredProcedure [dbo].[GetEmployees]    Script Date: 7/29/2022 2:05:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetEmployees]    
as    
begin    
   select * from Employee  
End   
GO
/****** Object:  StoredProcedure [dbo].[UpdateEmpDetails]    Script Date: 7/29/2022 2:05:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UpdateEmpDetails]  
(  
   @Id int,  
   @Name varchar (50),  
   @City varchar (50),  
   @Address varchar (50)  
)  
as  
begin  
   Update Employee  
   set Name=@Name,  
   City=@City,  
   Address=@Address  
   where Id=@Id  
End  

GO
