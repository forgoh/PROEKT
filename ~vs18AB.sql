/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Id]
      ,[Dni]
      ,[Nombres]
      ,[Apellidos]
      ,[Cargo]
      ,[Email]
      ,[Contraseña]
  FROM [LoginAp].[dbo].[Usuarios]