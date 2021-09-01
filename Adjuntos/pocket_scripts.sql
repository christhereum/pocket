-- Borra tablas
IF OBJECT_ID('pagos', 'U') IS NOT NULL
	DROP TABLE pagos

IF OBJECT_ID('adelantos', 'U') IS NOT NULL
	DROP TABLE adelantos

IF OBJECT_ID('empleados', 'U') IS NOT NULL
	DROP TABLE empleados

IF OBJECT_ID('tipos_empleado', 'U') IS NOT NULL
	DROP TABLE tipos_empleado

-- Borra FKs
IF (OBJECT_ID('FK_PagoAdelanto', 'F') IS NOT NULL)
	ALTER TABLE pagos DROP CONSTRAINT FK_PagoAdelanto

IF (OBJECT_ID('FK_AdelantoEmpleado', 'F') IS NOT NULL)
	ALTER TABLE adelantos DROP CONSTRAINT FK_AdelantoEmpleado

IF (OBJECT_ID('FK_EmpleadoTipoEmpleado', 'F') IS NOT NULL)
	ALTER TABLE empleados DROP CONSTRAINT FK_EmpleadoTipoEmpleado


-- Crea Tablas
IF OBJECT_ID('tipos_empleado', 'U') IS NULL
	CREATE TABLE tipos_empleado (
		id CHAR(1) NOT NULL,
		descripcion VARCHAR(50) NOT NULL,
		porcentaje_adelanto INT NOT NULL,
		PRIMARY KEY (id)
	)

IF OBJECT_ID('empleados', 'U') IS NULL
	CREATE TABLE empleados (
		legajo INT IDENTITY(1, 1) NOT NULL,
		tipo_empleado CHAR(1) NOT NULL,
		dni INT NOT NULL,
		nombre VARCHAR(50) NOT NULL,
		apellido VARCHAR(50) NOT NULL,
		sueldo INT NOT NULL,
		PRIMARY KEY (legajo),
		CONSTRAINT FK_EmpleadoTipoEmpleado FOREIGN KEY (tipo_empleado) REFERENCES tipos_empleado(id)
	)

IF OBJECT_ID('adelantos', 'U') IS NULL
	CREATE TABLE adelantos (
		id CHAR(10) NOT NULL,
		legajo INT NOT NULL,
		monto DECIMAL(10, 2) NOT NULL,
		fecha DATETIME DEFAULT GETDATE() NULL,
		fecha_cancelacion DATETIME NULL,
		PRIMARY KEY (id),
		CONSTRAINT FK_AdelantoEmpleado FOREIGN KEY (legajo) REFERENCES empleados(legajo)
	)

IF OBJECT_ID('pagos', 'U') IS NULL
	CREATE TABLE pagos (
		id INT IDENTITY(1, 1) NOT NULL,
		id_adelanto CHAR(10) NOT NULL,
		monto DECIMAL(10, 2) NOT NULL,
		fecha DATETIME NOT NULL,
		PRIMARY KEY (id),
		CONSTRAINT FK_PagoAdelanto FOREIGN KEY (id_adelanto) REFERENCES adelantos(id)
	)

-- Inserta Tipos de Empleado por defecto
INSERT INTO tipos_empleado (id, descripcion, porcentaje_adelanto) VALUES ('O', 'Operario', 20)
INSERT INTO tipos_empleado (id, descripcion, porcentaje_adelanto) VALUES ('A', 'Administrativo', 50)
INSERT INTO tipos_empleado (id, descripcion, porcentaje_adelanto) VALUES ('D', 'Directivo', 80)

-- Select de tablas
SELECT * FROM tipos_empleado
SELECT * FROM empleados
SELECT * FROM adelantos
SELECT * FROM pagos

