CREATE DATABASE EXAMENPROGRA
GO

USE EXAMENPROGRA
GO

CREATE TABLE USUARIOS(

   UsuariosID int identity(1,1),
	Nombre varchar(50) NOT NULL,
	Correo varchar(50),
	Telefono  varchar(15)
	CONSTRAINT pk_UsuariosID PRIMARY KEY(UsuariosID) 
)
GO

CREATE TABLE EQUIPOS(

  EquiposID int identity(1,1),
  IDUsuarios int,
  TipoEquipo varchar(50) not null,
  Modelo varchar(50),
  constraint pk_EquiposID primary key (EquiposID),
  constraint fk_IDUsuarios foreign key (IDUsuarios) references USUARIOS(UsuariosID),

)
GO

CREATE TABLE REPARACIONES(

    ReparacionesID  int identity (1,1),	
	IDEquipos int,
	FechaSolicitud datetime CONSTRAINT FechaSolicitud DEFAULT GETDATE(),
	Estado char(1)
   CONSTRAINT pk_ReparacionesID PRIMARY KEY(ReparacionesID),
   CONSTRAINT fk_IDEquipos FOREIGN KEY(IDEquipos) REFERENCES EQUIPOS(EquiposID)

)
GO

CREATE TABLE TECNICOS(

    TecnicosID int identity(1,1),
	Nombre varchar(50) NOT NULL,
	Especialidad  varchar(50),
	CONSTRAINT pk_TecnicosID PRIMARY KEY(TecnicosID) 

)
GO


CREATE TABLE ASIGNACIONES(

   Asignaciones int identity (1,1),
   IDReparaciones int,
   IDTecnicos int,
   FechaAsignaciones datetime CONSTRAINT FechaAsignaciones DEFAULT GETDATE(),
   CONSTRAINT fk_IDReparaciones FOREIGN KEY(IDReparaciones) REFERENCES REPARACIONES(ReparacionesID),
   CONSTRAINT fk_IDTecnicos FOREIGN KEY(IDTecnicos) REFERENCES TECNICOS(TecnicosID)
)
GO

 CREATE TABLE DETALLESREPARACION(
    
	DetalleID int identity (1,1),
    IDReparacione int,
	descripcion varchar (50) NOT NULL,
	fechaInicio datetime CONSTRAINT df_fechaInicio DEFAULT GETDATE(),
	fechaFin datetime CONSTRAINT df_fechaFin DEFAULT GETDATE(),
	CONSTRAINT pk_DetalleID PRIMARY KEY(DetalleID), 
    CONSTRAINT fk_IDReparacione FOREIGN KEY(IDReparacione) REFERENCES REPARACIONES(ReparacionesID)


)
GO

--=====================================================================================================
--Procedimientos
--=====================================================================================================

 INSERT INTO USUARIOS(Nombre, Correo, Telefono) Values ('Alessandro','Ale@Cam.com','72608432'), ('Gabriel','GAB@Cam.com','72903432'), ('Orlando','ORL@Cam.com','73628232')
 GO
 
 INSERT INTO EQUIPOS(IDUsuarios, TipoEquipo , Modelo) Values ( 1 , 'Laptop','Lenovo2019') , ( 2 , 'PC','XPG2021'),( 3 , 'Lactop','HP2023')
 GO


 INSERT INTO REPARACIONES(IDEquipos, Estado) Values (1,'X'),(2,'Y'),(3,'Z')
 GO

  INSERT INTO TECNICOS(Nombre,Especialidad) Values('Alessandro','Programador'), ('Gabriel','Programador'),('Orlando','Desarollador')
 GO

  INSERT INTO ASIGNACIONES(IDReparaciones,IDTecnicos) Values (1,1),(2,2),(3,3)
 GO

  INSERT INTO DETALLESREPARACION( IDReparacione,descripcion) Values (1 , 'Aumento de memoria RAM') , (2,'Cambio de tarjeta madre') , (3, 'Reparacion de procesador')
 GO

 --=====================================================================================================

 --CONSULTAR
 --=====================================================================================================
 CREATE PROCEDURE CONSULTAR_USUARIO
 AS 
    BEGIN	
			SELECT * from USUARIOS
            END
	GO


 CREATE PROCEDURE CONSULTAR_EQUIPOS
 AS 
    BEGIN	
			SELECT * from EQUIPOS
            END
	GO


CREATE PROCEDURE CONSULTAR_TECNICOS
AS
    BEGIN 
	 SELECT * FROM TECNICOS
	 END
GO

--=====================================================================================================

 --Borrar
 --=====================================================================================================

CREATE PROCEDURE BORRAR_Usuarios
@IDusarios INT
AS
   BEGIN 
   DELETE USUARIOS WHERE UsuariosID = @IDusarios
   END
GO


CREATE PROCEDURE BORRAR_EQUIPOS
@IDequipos INT
AS
   BEGIN 
   DELETE EQUIPOS WHERE EquiposID  = @IDequipos
   END
GO


CREATE PROCEDURE BORRAR_TECNICOS
@IDtecnicos INT
AS
   BEGIN 
   DELETE TECNICOS WHERE TecnicosID = @IDtecnicos
   END
GO

--=====================================================================================================


 --AGREGAR
 --=====================================================================================================

 CREATE PROCEDURE AGREGAR_USUARIOS
 @Nombre VARCHAR(50),
 @Correo VARCHAR(50),
 @Telefono VARCHAR(15)
 AS
   BEGIN 
           INSERT INTO USUARIOS(Nombre, Correo, Telefono) Values (@Nombre,@Correo,@Telefono)
		   END
GO


 CREATE PROCEDURE AGREGAR_EQUIPOS
 @IDUsuarios int,
 @TipoEquipo VARCHAR(50),
 @Modelo VARCHAR(50)
 AS
   BEGIN 
           INSERT INTO EQUIPOS(IDUsuarios, TipoEquipo , Modelo) Values (@IDUsuarios,@TipoEquipo,@Modelo)
		   END
GO


 CREATE PROCEDURE AGREGAR_TECNICOS
 @Nombre VARCHAR(50),
 @Especialidad VARCHAR(50)
 AS
   BEGIN 
           INSERT INTO TECNICOS(Nombre,Especialidad) Values (@Nombre,@Especialidad)
		   END
GO

--=====================================================================================================


 --Modificar
 --=====================================================================================================

 CREATE PROCEDURE MODIFICAR_USUARIOS
 @IDusarios int,
 @Nombre VARCHAR(50),
 @Correo VARCHAR(50),
 @Telefono VARCHAR(15)
  AS 
	BEGIN
	UPDATE USUARIOS SET Nombre = @Nombre , Correo= @Correo , Telefono = @Telefono WHERE UsuariosID = @IDusarios
	END
GO

 CREATE PROCEDURE MODIFICAR_EQUIPOS
 @IDequipos int,
 @TipoEquipo VARCHAR(50),
 @Modelo VARCHAR(50)
  AS 
	BEGIN
	UPDATE EQUIPOS SET TipoEquipo = @TipoEquipo, Modelo= @Modelo WHERE EquiposID = @IDequipos
	END
GO

 CREATE PROCEDURE MODIFICAR_TECNICOS
 @IDtecnicos int,
 @Nombre VARCHAR(50),
 @Especialidad VARCHAR(50)
  AS 
	BEGIN
	UPDATE TECNICOS SET Nombre = @Nombre, Especialidad= @Especialidad WHERE TecnicosID = @IDtecnicos
	END
GO

--=====================================================================================================

