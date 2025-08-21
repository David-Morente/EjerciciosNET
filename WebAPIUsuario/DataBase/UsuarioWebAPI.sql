CREATE DATABASE db_usuario
GO

USE db_usuario
GO

CREATE TABLE Usuario(
	id INT PRIMARY KEY IDENTITY,
	nombres VARCHAR(50) NOT NULL,
	apellidos VARCHAR(50) NOT NULL,
	correo VARCHAR(100) NOT NULL,
	username VARCHAR(100),
	fecha_creacion DATETIME
)
GO

SELECT * FROM Usuario

INSERT INTO Usuario VALUES ('Carlos', 'Ramírez López', 'carlos.ramirez@example.com', 'carlosr', GETDATE());
