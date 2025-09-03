DROP DATABASE IF EXISTS Store;
CREATE DATABASE Store;

USE Store;

CREATE TABLE Cliente(
	id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100),
    apellido VARCHAR(100)
);

CREATE TABLE User(
	id INT AUTO_INCREMENT PRIMARY KEY,
    correo VARCHAR(150),
    password VARCHAR(250) NOT NULL,
    cliente_id INT NOT NULL,
    FOREIGN KEY (cliente_id) REFERENCES Cliente(id)
);

INSERT INTO Cliente(nombre, apellido)
VALUES ('José', 'Morente');

INSERT INTO User(correo, password, cliente_id)
VALUES ('josemorenteg98@gmail.com', '12345', 1);
 

SELECT * FROM Cliente c
INNER JOIN User u ON u.cliente_id = c.id;

CREATE TABLE Categoria(
	id INT AUTO_INCREMENT PRIMARY KEY,
	nombre VARCHAR(100)
);

CREATE TABLE Producto(
	id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100),
    precio DECIMAL(10,2) NOT NULL,
    stock INT NOT NULL
);

CREATE TABLE Factura(
	id INT AUTO_INCREMENT PRIMARY KEY,
    fecha DATETIME,
    total INT NOT NULL,
    cliente_id INT NOT NULL,
    FOREIGN KEY (cliente_id) REFERENCES Cliente(id)
);

CREATE TABLE Detalle_Factura(
	id INT AUTO_INCREMENT PRIMARY KEY,
    factura_id INT NOT NULL,
    producto_id INT NOT NULL,
    cantidad INT NOT NULL,
    FOREIGN KEY (factura_id) REFERENCES Factura(id),
    FOREIGN KEY (producto_id) REFERENCES Producto(id)
);

INSERT INTO Categoria (nombre) VALUES
('Electrónica'),
('Ropa'),
('Alimentos'),
('Hogar');

INSERT INTO Producto (nombre, precio, stock) VALUES
('Laptop', 800.00, 10),
('Camisa', 20.00, 50),
('Arroz 5kg', 15.50, 100),
('Silla de oficina', 120.00, 15);

INSERT INTO Factura (fecha, total, cliente_id) VALUES
(NOW(), 820, 1),
(NOW(), 155.50, 1);

INSERT INTO Detalle_Factura (factura_id, producto_id, cantidad) VALUES
(1, 1, 1),
(1, 2, 1),
(2, 3, 10);

SELECT * FROM Categoria;
SELECT * FROM Producto;
SELECT * FROM Factura;
SELECT * FROM Detalle_Factura;
