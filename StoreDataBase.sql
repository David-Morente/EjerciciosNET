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

CREATE TABLE Usuario(
	id INT AUTO_INCREMENT PRIMARY KEY,
    correo VARCHAR(150),
    password VARCHAR(250) NOT NULL,
    cliente_id INT NOT NULL,
    FOREIGN KEY (cliente_id) REFERENCES Cliente(id)
);

CREATE TABLE Categoria(
	id INT AUTO_INCREMENT PRIMARY KEY,
	nombre VARCHAR(100)
);

CREATE TABLE Proveedor(
	id INT AUTO_INCREMENT PRIMARY KEY,
    nombre_empresa VARCHAR(100)
);

CREATE TABLE Direccion_Proveedor(
	id INT AUTO_INCREMENT PRIMARY KEY,
	calle VARCHAR(100),
    codigo_postal INT NOT NULL,
    ciudad VARCHAR (100),
    proveedor_id INT NOT NULL,
    FOREIGN KEY (proveedor_id) REFERENCES Proveedor(id)
);

CREATE TABLE Categoria_Insumo(
	id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL
);

CREATE TABLE Insumo(
	id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    stock INT NOT NULL,
    precio DECIMAL(10,2) NOT NULL,
    categoriaInsumo_id INT NOT NULL,
    proveedor_id INT NOT NULL,
    FOREIGN KEY (categoriaInsumo_id) REFERENCES Categoria_Insumo(id),
	FOREIGN KEY (proveedor_id) REFERENCES Proveedor(id)
);

CREATE TABLE Compra_Proveedor(
	id INT AUTO_INCREMENT PRIMARY KEY,
    fecha DATETIME NOT NULL,
    proveedor_id INT NOT NULL,
    total DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (proveedor_id) REFERENCES Proveedor(id)
);

CREATE TABLE Detalle_Compra(
	id INT AUTO_INCREMENT PRIMARY KEY,
    compra_id INT NOT NULL,
    insumo_id INT NOT NULL,
    cantidad INT NOT NULL,
    precio_unitario DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (compra_id) REFERENCES Compra_Proveedor(id),
    FOREIGN KEY (insumo_id) REFERENCES Insumo(id)
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
    nombre VARCHAR(100),
	direccion VARCHAR(150)
);

CREATE TABLE Factura(
	id INT AUTO_INCREMENT PRIMARY KEY,
    fecha DATETIME,
    total DECIMAL NOT NULL,
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
('María', 'López'),
('Carlos', 'Ramírez'),
('Ana', 'García'),
('Luis', 'Martínez'),
('Sofía', 'Hernández'),
('Pedro', 'Castillo'),
('Laura', 'Morales'),
('Diego', 'Flores'),
('Elena', 'Torres');

INSERT INTO Direccion (calle, codigo_postal, ciudad, cliente_id) VALUES
('Calle 1', 1001, 'Guatemala', 1),
('Avenida Reforma 2', 1002, 'Guatemala', 2),
('Zona 5', 1003, 'Guatemala', 3),
('Boulevard Vista', 1004, 'Guatemala', 4),
('Colonia Las Flores', 1005, 'Mixco', 5),
('Zona 10', 1006, 'Guatemala', 6),
('Carretera El Salvador', 1007, 'Santa Catarina', 7),
('Zona 1', 1008, 'Guatemala', 8),
('Zona 18', 1009, 'Guatemala', 9),
('Barrio San Pedro', 1010, 'Antigua', 10);

INSERT INTO Usuario (correo, password, cliente_id) VALUES
('juan@mail.com', 'pass1', 1),
('maria@mail.com', 'pass2', 2),
('carlos@mail.com', 'pass3', 3),
('ana@mail.com', 'pass4', 4),
('luis@mail.com', 'pass5', 5),
('sofia@mail.com', 'pass6', 6),
('pedro@mail.com', 'pass7', 7),
('laura@mail.com', 'pass8', 8),
('diego@mail.com', 'pass9', 9),
('elena@mail.com', 'pass10', 10);

INSERT INTO Proveedor (nombre_empresa) VALUES
('Distribuidora La Central'),
('Insumos y Más'),
('Tech Importaciones'),
('OfiMax'),
('Limpieza Total'),
('Papelería Mundial'),
('Empaques Express'),
('ElectroDistribuidor'),
('Global Supplies'),
('Mega Proveedores');

INSERT INTO Direccion_Proveedor (calle, codigo_postal, ciudad, proveedor_id) VALUES
('Av. Las Américas', 2001, 'Guatemala', 1),
('Zona 12', 2002, 'Guatemala', 2),
('Zona 4', 2003, 'Guatemala', 3),
('Zona 7', 2004, 'Guatemala', 4),
('Zona 8', 2005, 'Guatemala', 5),
('Zona 9', 2006, 'Mixco', 6),
('Zona 11', 2007, 'Guatemala', 7),
('Zona 14', 2008, 'Guatemala', 8),
('Zona 15', 2009, 'Guatemala', 9),
('Zona 16', 2010, 'Guatemala', 10);

INSERT INTO Categoria (nombre) VALUES
('Electrónica'),
('Ropa'),
('Juguetes'),
('Calzado'),
('Accesorios'),
('Alimentos'),
('Bebidas'),
('Hogar'),
('Deportes'),
('Videojuegos');

INSERT INTO Categoria_Insumo (nombre) VALUES
('Limpieza'),
('Oficina'),
('Embalaje'),
('Tecnología'),
('Mantenimiento'),
('Higiene'),
('Seguridad'),
('Papelería'),
('Herramientas'),
('Otros');

INSERT INTO Insumo (nombre, stock, precio, categoriaInsumo_id, proveedor_id) VALUES
('Detergente', 50, 25.50, 1, 1),
('Escoba', 30, 40.00, 1, 2),
('Hojas A4 (resma)', 100, 35.00, 2, 3),
('Cinta adhesiva', 80, 15.00, 3, 4),
('Cajas de cartón', 60, 10.00, 3, 5),
('Tóner impresora', 20, 150.00, 4, 6),
('Guantes de limpieza', 40, 18.00, 5, 7),
('Gel antibacterial', 70, 12.50, 6, 8),
('Cámara de seguridad', 15, 300.00, 7, 9),
('Destornillador', 25, 22.00, 9, 10);

INSERT INTO Compra_Proveedor (fecha, proveedor_id, total) VALUES
('2025-09-01 10:00:00', 1, 2550.00),
('2025-09-02 11:30:00', 2, 1200.00),
('2025-09-03 09:15:00', 3, 1800.00),
('2025-09-04 14:20:00', 4, 950.00),
('2025-09-05 16:10:00', 5, 2000.00),
('2025-09-06 12:00:00', 6, 1750.00),
('2025-09-07 15:45:00', 7, 2100.00),
('2025-09-08 13:50:00', 8, 3100.00),
('2025-09-09 17:30:00', 9, 2700.00),
('2025-09-10 08:40:00', 10, 500.00);

INSERT INTO Detalle_Compra (compra_id, insumo_id, cantidad, precio_unitario) VALUES
(1, 1, 20, 25.50),
(2, 2, 10, 40.00),
(3, 3, 30, 35.00),
(4, 4, 15, 15.00),
(5, 5, 40, 10.00),
(6, 6, 5, 150.00),
(7, 7, 20, 18.00),
(8, 8, 25, 12.50),
(9, 9, 5, 300.00),
(10, 10, 10, 22.00);

INSERT INTO Producto (nombre, precio, stock, categoria_id) VALUES
('Smartphone', 2500.00, 20, 1),
('Laptop', 6000.00, 15, 1),
('Camisa', 150.00, 50, 2),
('Pantalón', 250.00, 40, 2),
('Pelota de fútbol', 200.00, 30, 9),
('Auriculares', 350.00, 25, 1),
('Sandalias', 180.00, 35, 4),
('Collar', 120.00, 60, 5),
('Cereal', 45.00, 100, 6),
('Juego de PlayStation', 1200.00, 10, 10);

INSERT INTO Tienda (nombre, direccion) VALUES 
('Tienda El Ahorro', 'Av. Central 123, Ciudad de Guatemala'),
('Supermercado La Económica', 'Calle 10 No. 45, Mixco'),
('Mini Market San Juan', 'Boulevard Principal Zona 7, Ciudad de Guatemala'),
('Bodega Las Flores', 'Km 15 Carretera a El Salvador, Santa Catarina Pinula'),
('Almacén El Centro', '6a Avenida 4-55, Zona 1, Ciudad de Guatemala'),
('Comercial Los Amigos', '3a Calle 12-34, Quetzaltenango'),
('Mercado Moderno', '2a Avenida 8-90, Antigua Guatemala'),
('Despensa Familiar Sur', 'Carretera al Pacífico Km 12, Villa Nueva'),
('Super Bodega Norte', 'Anillo Periférico 22-10, Zona 11, Ciudad de Guatemala'),
('Distribuidora San Martín', 'Calle Real 7-20, Chimaltenango');

INSERT INTO Factura (fecha, total, cliente_id, tienda_id) VALUES
('2025-09-01 09:00:00', 500.00, 1, 1),
('2025-09-02 10:15:00', 1200.00, 2, 2),
('2025-09-03 11:30:00', 250.00, 3, 3),
('2025-09-04 14:00:00', 6000.00, 4, 4),
('2025-09-05 15:10:00', 180.00, 5, 5),
('2025-09-06 16:25:00', 350.00, 6, 6),
('2025-09-07 17:40:00', 700.00, 7, 7),
('2025-09-08 12:50:00', 900.00, 8, 8),
('2025-09-09 13:30:00', 1500.00, 9, 9),
('2025-09-10 18:45:00', 1200.00, 10, 10);

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

SELECT * FROM Cliente c
INNER JOIN Usuario u ON u.cliente_id = c.id;

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
