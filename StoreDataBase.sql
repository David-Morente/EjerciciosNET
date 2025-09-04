DROP DATABASE IF EXISTS Store;
CREATE DATABASE Store;

USE Store;

CREATE TABLE Cliente(
	id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100),
    apellido VARCHAR(100)
);

CREATE TABLE Direccion(
	id INT AUTO_INCREMENT PRIMARY KEY,
	calle VARCHAR(100),
    codigo_postal INT NOT NULL,
    ciudad VARCHAR (100),
    cliente_id INT NOT NULL,
    FOREIGN KEY (cliente_id) REFERENCES Cliente(id)
);

CREATE TABLE User(
	id INT AUTO_INCREMENT PRIMARY KEY,
    correo VARCHAR(150),
    password VARCHAR(250) NOT NULL,
    cliente_id INT NOT NULL,
    FOREIGN KEY (cliente_id) REFERENCES Cliente(id)
);

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
    stock INT NOT NULL,
    categoria_id INT NOT NULL,
    FOREIGN KEY (categoria_id) REFERENCES Categoria(id)
);

CREATE TABLE Tienda(
	id INT AUTO_INCREMENT PRIMARY KEY,
	direccion VARCHAR(150)
);

CREATE TABLE Factura(
	id INT AUTO_INCREMENT PRIMARY KEY,
    fecha DATETIME,
    total INT NOT NULL,
    cliente_id INT NOT NULL,
    tienda_id INT NOT NULL,
    FOREIGN KEY (cliente_id) REFERENCES Cliente(id),
    FOREIGN KEY (tienda_id) REFERENCES Tienda(id)
);

CREATE TABLE Detalle_Factura(
	id INT AUTO_INCREMENT PRIMARY KEY,
    factura_id INT NOT NULL,
    producto_id INT NOT NULL,
    cantidad INT NOT NULL,
    FOREIGN KEY (factura_id) REFERENCES Factura(id),
    FOREIGN KEY (producto_id) REFERENCES Producto(id)
);

INSERT INTO Cliente (nombre, apellido) VALUES
('Juan', 'Pérez'),
('María', 'Gómez'),
('Carlos', 'Ramírez'),
('Ana', 'López'),
('Pedro', 'Martínez'),
('Lucía', 'Fernández'),
('Miguel', 'Torres'),
('Sofía', 'Hernández'),
('David', 'Castillo'),
('Elena', 'Morales');

INSERT INTO Direccion (calle, codigo_postal, ciudad, cliente_id) VALUES
('Av. Reforma 123', 1001, 'Guatemala', 1),
('Calle Central 45', 1002, 'Mixco', 2),
('Colonia Bella 67', 1003, 'Villa Nueva', 3),
('Zona 10 Torre 8', 1004, 'Guatemala', 4),
('Residencial Los Olivos', 1005, 'Antigua', 5),
('Av. Petapa 55', 1006, 'Guatemala', 6),
('Calle Real 89', 1007, 'Amatitlán', 7),
('Barrio San José', 1008, 'Escuintla', 8),
('Zona 15', 1009, 'Guatemala', 9),
('Residencial Las Flores', 1010, 'Mixco', 10);

INSERT INTO User (correo, password, cliente_id) VALUES
('juanperez@mail.com', '1234', 1),
('maria@mail.com', 'abcd', 2),
('carlos@mail.com', 'pass123', 3),
('ana@mail.com', 'qwerty', 4),
('pedro@mail.com', 'pedro123', 5),
('lucia@mail.com', 'lucia456', 6),
('miguel@mail.com', 'miguel789', 7),
('sofia@mail.com', 'sofia321', 8),
('david@mail.com', 'david654', 9),
('elena@mail.com', 'elena987', 10);

INSERT INTO Categoria (nombre) VALUES
('Abarrotes'),
('Electrónica'),
('Hogar'),
('Ropa'),
('Lácteos'),
('Bebidas'),
('Limpieza'),
('Frutas y Verduras'),
('Carnes'),
('Panadería');

INSERT INTO Producto (nombre, precio, stock, categoria_id) VALUES
('Arroz Diana 5kg', 90.00, 200, 1),
('Frijoles Rojos 2lb', 35.00, 300, 1),
('Leche Dos Pinos 1L', 18.00, 500, 5),
('Coca Cola 2.5L', 25.00, 400, 6),
('Pollo Entero 1kg', 45.00, 150, 9),
('Pan Bimbo Familiar', 32.00, 250, 10),
('Detergente Ariel 3kg', 120.00, 180, 7),
('Televisor Samsung 50"', 3500.00, 20, 2),
('Celular Motorola G32', 1500.00, 30, 2),
('Camiseta Básica Hombre', 60.00, 100, 4);

INSERT INTO Tienda (direccion) VALUES
('Walmart Zona 1, Guatemala'),
('Walmart Zona 10, Guatemala'),
('Walmart Mixco San Cristóbal'),
('Walmart Antigua Guatemala'),
('Walmart Villa Nueva'),
('Walmart Escuintla Centro'),
('Walmart Quetzaltenango'),
('Walmart Huehuetenango'),
('Walmart Chimaltenango'),
('Walmart Zona 18, Guatemala');

INSERT INTO Factura (fecha, total, cliente_id, tienda_id) VALUES
(NOW(), 600, 1, 1),
(NOW(), 150, 2, 2),
(NOW(), 2500, 3, 3),
(NOW(), 3800, 4, 4),
(NOW(), 90, 5, 5),
(NOW(), 75, 6, 6),
(NOW(), 500, 7, 7),
(NOW(), 3600, 8, 8),
(NOW(), 120, 9, 9),
(NOW(), 1800, 10, 10);

INSERT INTO Detalle_Factura (factura_id, producto_id, cantidad) VALUES
(1, 1, 2),
(1, 2, 3),
(1, 3, 5),
(2, 4, 2),
(2, 6, 1),
(3, 8, 1),
(3, 7, 2),
(3, 5, 4),
(4, 9, 1),
(4, 10, 5),
(5, 1, 1),
(6, 2, 1),
(6, 3, 2),
(6, 4, 1),
(7, 7, 1),
(7, 6, 2),
(7, 5, 2),
(8, 8, 1),
(8, 9, 1),
(9, 3, 4),
(9, 6, 2),
(10, 10, 10),
(10, 4, 5),
(10, 5, 3);

SELECT * FROM Categoria;
SELECT * FROM Producto;
SELECT * FROM Factura;
SELECT * FROM Detalle_Factura;

-- TOP 5 PRODUCTOS MAS VENDIDOS
SELECT p.nombre, SUM(df.cantidad) AS cantidad FROM Detalle_Factura df
INNER JOIN Producto p ON p.id = df.producto_id
GROUP BY p.nombre
ORDER BY SUM(df.cantidad) DESC
LIMIT 5;

-- TOP 5 PRODUCTOS MENOS VENDIDOS
SELECT p.nombre, SUM(df.cantidad) AS cantidad FROM Detalle_Factura df
INNER JOIN Producto p ON p.id = df.producto_id
GROUP BY p.nombre
ORDER BY SUM(df.cantidad) ASC
LIMIT 5;
