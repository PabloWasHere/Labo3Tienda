
CREATE TABLE usuario
(
	id int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	nick varchar(50),
	password varchar(50),
	nombre varchar(50),
	apellido varchar(50),
	creado datetime,
	modificado datetime,
	activo bit
);

CREATE TABLE permiso
(
	id int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	codigo varchar(50),
	descripcion varchar(200)
);

CREATE TABLE rol
(
	id int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	codigo varchar(50),
	descripcion varchar(200)
);

CREATE TABLE usuario_rol
(
	usuario_id int references usuario,
	rol_id int references rol
);

CREATE TABLE rol_permiso
(
	rol_id int references rol,
	permiso_id int references permiso
);

CREATE TABLE cliente
(
	id int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	propietario_id references usuario,
	es_organizacion bit,
	nombre_organizacion varchar(200),
	genero varchar(1),
	primer_nombre varchar(200),
	segundo_nombre varchar(200),
	apellido varchar(200),
	correo_electronico varchar(200),
	numero_telefono varchar(200),
	direccion varchar(200),
	pueblo_ciudad varchar(200),
	pais varchar(200),
	creado datetime,
	modificado datetime,
	usuario_id int references usuario,
	activo bit
);

CREATE TABLE metodo_pago
(
	id int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	codigo varchar(200),
	descripcion varchar(200)
);
/* TC = Tarjeta de Credito */

CREATE TABLE cliente_metodo_pago
(
	id int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	cliente_id int references cliente,
	metodo_pago_id int references metodo_pago,
	numero_tarjeta_credito varchar(200),
	detalles varchar(500)
);

CREATE TABLE producto_tipo
(
	id int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	producto_tipo_padre_id int references producto_tipo,
	codigo varchar(200),
	descripcion varchar(500),
	creado datetime,
	modificado datetime,
	usuario_id int references usuario,
	activo bit
);
/* Libro, CD, Ropa */

CREATE TABLE producto
(
	id int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	producto_tipo_id int references producto_tipo,
	stock int,
	nombre varchar(200),
	precio decimal,
	descripcion varchar(500),
	otros_detalles varchar(500),
	creado datetime,
	modificado datetime,
	usuario_id int references usuario,
	activo bit
);

CREATE TABLE orden_codigo_estado
(
	id int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	codigo varchar(200),
	descripcion varchar(500)
);
/* Completado, Cancelado */

CREATE TABLE orden
(
	id int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	cliente_id int references cliente,
	orden_codigo_estado_id int references orden_codigo_estado,
	fecha_pedido datetime,
	detalles varchar(500),
	creado datetime,
	modificado datetime,
	usuario_id int references usuario,
	activo bit
);

CREATE TABLE item_orden_codigo_estado
(
	id int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	descripcion varchar(200)
);
/* Entregado, Fuera de stock */

CREATE TABLE item_orden
(
	id int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	producto_id int references producto,
	orden_id int references orden,
	item_orden_codigo_estado_id int references item_orden_codigo_estado,
	cantidad int,
	precio decimal,
	detalles varchar(500),
	creado datetime,
	modificado datetime,
	usuario_id int references usuario,
	activo bit
);

CREATE TABLE factura
(
	id int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	orden_id int references orden,
	numero int,
	fecha datetime,
	detalles varchar(500)
);

CREATE TABLE envio
(
	id int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	orden_id int references orden,
	factura_id int references factura,
	numero_seguimiento int,
	fecha datetime,
	detalles varchar(500)
);
