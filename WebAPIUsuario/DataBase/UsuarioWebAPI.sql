DROP DATABASE db_user
DROP TABLE Usuario

CREATE DATABASE db_user
GO

Use master

USE db_user
GO

CREATE TABLE Usuario(
	id INT PRIMARY KEY IDENTITY,
	nombres VARCHAR(50) NOT NULL,
	apellidos VARCHAR(50) NOT NULL,
	correo VARCHAR(100) NOT NULL,
	username VARCHAR(100),
	password VARCHAR(255) NOT NULL,
	fecha_creacion DATETIME
)
GO

SELECT * FROM Usuario

INSERT INTO Usuario VALUES ('Carlos', 'Ramírez López', 'carlos.ramirez@example.com', 'carlosr', 'carlos123', GETDATE());
