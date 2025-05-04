CREATE DATABASE DB_EDUWEB;

USE DB_EDUWEB;

CREATE TABLE Estudiantes(
	IdEstudiante NVARCHAR(100) PRIMARY KEY,
	Nombres NVARCHAR(100),
	Apellidos NVARCHAR(100),
	FechaNacimiento DATETIME,
	Clave NVARCHAR(100)
);

CREATE TABLE Docentes(
	IdDocente NVARCHAR(100) PRIMARY KEY,
	Nombres NVARCHAR(100),
	Apellidos NVARCHAR(100),
	FechaNacimiento DATETIME,
	Clave NVARCHAR(100)
);

CREATE TABLE Padres(
	IdPadre NVARCHAR(100) PRIMARY KEY,
	IdEstudiante NVARCHAR(100),
	Nombres NVARCHAR(100),
	Apellidos NVARCHAR(100),
	FechaNacimiento DATETIME,
	Clave NVARCHAR(100),
	CONSTRAINT FK_Padres_Estudiantes FOREIGN KEY (IdEstudiante) REFERENCES Estudiantes(IdEstudiante),
);

CREATE TABLE Areas(
	IdArea INTEGER IDENTITY(1, 1) PRIMARY KEY,
	Nombre NVARCHAR(100)
);

CREATE TABLE ContenidosMultimedia(
	Id INTEGER IDENTITY(1, 1) PRIMARY KEY,
	IdArea INTEGER,
	RutaRecurso NVARCHAR(100),
	CONSTRAINT FK_LeccionesMultimedia_Areas FOREIGN KEY (IdArea) REFERENCES Areas(IdArea)
);

CREATE TABLE ProgresoEstudiante(
	IdEstudiante NVARCHAR(100),
	IdArea INTEGER,
	ActividadesRealizadas INTEGER,
	CONSTRAINT FK_ProgresoEstudiante_Estudiantes FOREIGN KEY (IdEstudiante) REFERENCES Estudiantes(IdEstudiante),
	CONSTRAINT FK_ProgresoEstudiante_Areas FOREIGN KEY (IdArea) REFERENCES Areas(IdArea)
)

CREATE TABLE RecomendacionesApoyo(
	IdDocente NVARCHAR(100),
	IdEstudiante NVARCHAR(100),
	IdArea INTEGER,
	Descripcion NVARCHAR(MAX),
	Fecha DATETIME DEFAULT GETDATE(),
	CONSTRAINT FK_RecomendacionesApoyo_Docentes FOREIGN KEY (IdDocente) REFERENCES Docentes(IdDocente),
	CONSTRAINT FK_RecomendacionesApoyo_Estudiantes FOREIGN KEY (IdEstudiante) REFERENCES Estudiantes(IdEstudiante),
	CONSTRAINT FK_RecomendacionesApoyo_Areas FOREIGN KEY (IdArea) REFERENCES Areas(IdArea)
)