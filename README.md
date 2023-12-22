---Create Table in ssms

 [Id][set as primary key]
      ,[FIrstName]
      ,[LastName]
      ,[Email]
      ,[Mobile]
      ,[Address]


      create stored procedures for Create Edit Read Delete

      ----AddOrEdit

      USE [Student_Jquery_DB]
GO
/****** Object:  StoredProcedure [dbo].[SPAddOrEditStudent]    Script Date: 12/22/2023 10:07:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[SPAddOrEditStudent]
(	
	@Id				int,
	@FirstName		varchar(50),
	@LastName		varchar(50),
	@Email			varchar(50),
	@Mobile			varchar(50),
	@Address		varchar(50)
)
as
If @Id=0
Begin
	insert into tbl_Student (FirstName,
							 LastName,	
							 Email,		
							 Mobile,		
							 Address)
	values (@FirstName,	
			@LastName,	
			@Email,		
			@Mobile,	
			@Address)
			
end
else
begin
	update tbl_Student
	set
	FirstName	=@FirstName	,
	LastName	=@LastName	,
	Email		=@Email	,	
	Mobile		=@Mobile,		
	Address	=@Address
	where Id=@Id
end


--Get all 
USE [Student_Jquery_DB]
GO
/****** Object:  StoredProcedure [dbo].[SPGetAllStudent]    Script Date: 12/22/2023 10:08:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[SPGetAllStudent]

as
begin
	select *
	from tbl_Student
	with(nolock)
end



----Delete
USE [Student_Jquery_DB]
GO
/****** Object:  StoredProcedure [dbo].[SPdeleteStudent]    Script Date: 12/22/2023 10:09:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[SPdeleteStudent]
(@Id int)
as
begin
	delete from tbl_Student where Id=@Id
end
