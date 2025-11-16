-- Script de creación mínima para la base de datos 'reservasdb'
CREATE DATABASE IF NOT EXISTS reservasdb;
USE reservasdb;

CREATE TABLE IF NOT EXISTS Salas (
  IdSala INT AUTO_INCREMENT PRIMARY KEY,
  NombreSala VARCHAR(100),
  Ubicacion VARCHAR(100),
  Capacidad INT,
  Distribucion VARCHAR(100),
  TieneProyector TINYINT(1) DEFAULT 0,
  TieneOasis TINYINT(1) DEFAULT 0,
  TieneCafetera TINYINT(1) DEFAULT 0,
  TienePizarra TINYINT(1) DEFAULT 0,
  TieneAireAcondicionado TINYINT(1) DEFAULT 0,
  OtrosEquipos TEXT,
  Disponible TINYINT(1) DEFAULT 1
);

CREATE TABLE IF NOT EXISTS Usuarios (
  IdUsuario INT AUTO_INCREMENT PRIMARY KEY,
  Nombre VARCHAR(100),
  Email VARCHAR(100),
  Telefono VARCHAR(50),
  Usuario VARCHAR(50),
  Password VARCHAR(255),
  Rol VARCHAR(50),
  Activo TINYINT(1) DEFAULT 1
);

CREATE TABLE IF NOT EXISTS Reservas (
  IdReserva INT AUTO_INCREMENT PRIMARY KEY,
  IdSala INT,
  IdUsuario INT,
  FechaReserva DATE,
  HoraInicio TIME,
  HoraFin TIME,
  Duracion DECIMAL(6,2),
  NombreResponsable VARCHAR(150),
  EmailResponsable VARCHAR(150),
  TelefonoResponsable VARCHAR(50),
  PropositoEvento TEXT,
  Subtotal DECIMAL(10,2),
  IVA DECIMAL(10,2),
  Total DECIMAL(10,2),
  Estado VARCHAR(50),
  FOREIGN KEY (IdSala) REFERENCES Salas(IdSala),
  FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario)
);

CREATE TABLE IF NOT EXISTS AsistentesReserva (
  IdAsistente INT AUTO_INCREMENT PRIMARY KEY,
  IdReserva INT,
  NombreAsistente VARCHAR(150),
  ComboSeleccionado INT,
  FOREIGN KEY (IdReserva) REFERENCES Reservas(IdReserva)
);
