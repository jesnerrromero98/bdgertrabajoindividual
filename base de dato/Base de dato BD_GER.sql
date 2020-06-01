CREATE DATABASE bd_ger1
GO
USE bd_ger1

CREATE TABLE Usuarios(
idusuario int primary key identity (1,1),
cedula varchar (14),
nombres varchar (50),
apellidos varchar (50),
email varchar (80),
telefono varchar (10)
constraint Usuario_Cedula UNIQUE (cedula, email, telefono));

	insert into Usuarios values ('2121231','juan','fefe','sfsf',5555);
	insert into Usuarios values ('34321','jose','fdf','dsjjfs',555532);
	insert into Usuarios values ('653411','jose','adad','sfff',5454);
	insert into Usuarios values ('24343231','jose','asdado','sfs',5333);

CREATE TABLE Cuentas(
idcuenta int primary key identity (1,1),
nombreuser varchar (30),
clave varchar (30),
idusuario int,
foreign key (idusuario) references Usuarios (idusuario),
CONSTRAINT nombreUser_Clave UNIQUE (clave, nombreuser));

CREATE TABLE Recursos(
idrecursos int primary key identity (1,1),
nombrer varchar (50),
codigo varchar (50),
descripcion varchar (50),
CONSTRAINT NombreRecurso_Codigo UNIQUE (nombrer, codigo));

CREATE TABLE Solicitud(
idsolicitud int primary key identity (1,1),
aula varchar (10),
nivel varchar (4),
fechasolicitud varchar(20),
fechauso varchar(20),
horainicio varchar(20),
horafinal varchar (20),
carrera varchar (max),
asignatura varchar (max),
idrecursos int,
idusuario int,
foreign key (idrecursos) references Recursos (idrecursos),
foreign key (idusuario) references Usuarios (idusuario),
CONSTRAINT Nivel CHECK (nivel='I' OR nivel= 'II' OR nivel='III' OR nivel='IV' OR nivel='V'));

CREATE TABLE Comentarios(
idcomentario int primary key identity (1,1),
nombres varchar (100) NOT NULL,
correo varchar (80) NOT NULL,
telefono varchar (10) NOT NULL,
mensaje varchar (max) NOT NULL
);

--Creacion de procedmiento almacenado

CREATE PROCEDURE Usuar
	@b int, @idusuario int, @cedula varchar (14), @nombres varchar (50), @apellidos varchar (50), @email varchar (80), @telefono varchar (10)

	AS
	BEGIN

		SET NOCOUNT ON;

		IF @b=1
			INSERT INTO Usuarios VALUES (@cedula, @nombres, @apellidos, @email, @telefono);
		IF @b=2
			DELETE FROM Usuarios WHERE idusuario=@idusuario;
		IF @b=3
			SELECT * FROM Usuarios
		IF @b=4
			UPDATE Usuarios SET cedula=@cedula, nombres=@nombres, apellidos=@apellidos, email=@email, telefono=@telefono WHERE idusuario=@idusuario;
		IF @b=5
			SELECT * FROM Usuarios WHERE nombres LIKE '%' + @nombres + '%'
	END
	GO


CREATE PROCEDURE Cuent
	@b int, @idcuenta int, @nombreuser varchar (30), @clave varchar (30), @idusuario int

	AS
	BEGIN

		SET NOCOUNT ON;

		IF @b=1
			INSERT INTO Cuentas VALUES (@nombreuser, @clave,@idusuario);
		IF @b=2
			DELETE FROM Cuentas WHERE idcuenta=@idcuenta;
		IF @b=3
			SELECT * FROM Cuentas
		IF @b=4
			UPDATE Cuentas SET nombreuser=@nombreuser, clave=@clave WHERE idcuenta=@idcuenta;
		IF @b=5
			SELECT * FROM Cuentas WHERE nombreuser LIKE '%' + @nombreuser + '%'
	END
	GO

CREATE PROCEDURE Recurs

	@b int, @idrecursos int, @nombrer varchar (50), @codigo varchar (50), @descripcion varchar (50)

	AS
	BEGIN

		SET NOCOUNT ON;

		IF @b=1
			INSERT INTO Recursos VALUES (@nombrer, @codigo, @descripcion);
		IF @b=2
			DELETE FROM Recursos WHERE idrecursos=@idrecursos;
		IF @b=3
			SELECT * FROM Recursos
			
		IF @b=4
			UPDATE Recursos SET nombrer=@nombrer, codigo=@codigo, descripcion=@descripcion WHERE idrecursos=@idrecursos;
		IF @b=5
			SELECT * FROM Recursos WHERE nombrer LIKE '%' + @nombrer + '%'

	END
alter PROCEDURE Solicit

	@b int, @idsolicitud int, @aula varchar (10), @nivel varchar (4), @fechasolicitud varchar(20), @fechauso varchar(20), @horainicio varchar(20), @horafinal varchar (20), @carrera varchar (max), @asignatura varchar(max),
	@idrecursos int,@idusuario int
	AS
	BEGIN

		SET NOCOUNT ON;

		IF @b=1
			INSERT INTO Solicitud VALUES (@aula, @nivel, @fechasolicitud, @fechauso, @horainicio, @horafinal, @carrera, @asignatura,@idrecursos,@idusuario);
		IF @b=2
			 DELETE FROM Solicitud WHERE idsolicitud=@idsolicitud;
		IF @b=3
			SELECT * FROM Solicitud
		IF @b=4
			UPDATE Solicitud SET aula=@aula, nivel=@nivel, fechasolicitud=@fechasolicitud, fechauso=@fechauso, horainicio=@horainicio, horafinal=@horafinal, carrera=@carrera, asignatura=@asignatura WHERE idsolicitud=@idsolicitud;
		IF @b=5
			SELECT * FROM Solicitud WHERE carrera LIKE '%' + @carrera + '%'

	END
	GO

CREATE PROCEDURE Comentar

	@b int, @idcomentario int, @nombres varchar(100), @correo varchar(50), @telefono varchar(10), @mensaje varchar(max)
	
	AS
	BEGIN

		SET NOCOUNT ON;

		IF @b=1
			INSERT INTO Comentarios VALUES (@nombres, @correo, @telefono, @mensaje);
		IF @b=2
			DELETE FROM Comentarios WHERE idcomentario=@idcomentario;
		IF @b=3
			SELECT * FROM Comentarios
		IF @b=4
			UPDATE Comentarios SET nombres=@nombres, correo=@correo, telefono=@telefono, mensaje=@mensaje WHERE idcomentario=@idcomentario;
		IF @b=5
			SELECT * FROM Comentarios WHERE nombres LIKE '%' + @nombres + '%'
	END
	GO
 create procedure RespaldoBD_GER
 as
 begin 
  set nocount on;
  BACKUP DATABASE [bd_ger1]
    TO DISK=N'F:\Backup\rbd_GER.bak'
	WITH CHECKSUM;
 END
 GO