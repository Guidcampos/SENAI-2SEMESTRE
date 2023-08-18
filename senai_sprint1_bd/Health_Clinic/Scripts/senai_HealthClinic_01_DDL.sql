--DDL Criando banco de dados

CREATE DATABASE [Health_Clinic_TARDE];
USE [Health_Clinic_TARDE];


--CRIANDO TABELAS 

CREATE TABLE [Clinica]
(
IdClinica INT PRIMARY KEY IDENTITY,
NomeFantasia VARCHAR(20) NOT NULL,
Endereco VARCHAR(100) NOT NULL,
CNPJ VARCHAR(15) NOT NULL UNIQUE,
RazaoSocial VARCHAR(30) NOT NULL
);

CREATE TABLE [TipoDeUsuario]
(
IdTipoUsuario INT PRIMARY KEY IDENTITY,
TituloTipoUsuario VARCHAR(30) NOT NULL
);

CREATE TABLE [Especialidade]
(
IdEspecialidade INT PRIMARY KEY IDENTITY,
TituloEspecialidade VARCHAR(20) NOT NULL 
);

CREATE TABLE [Usuario]
(
IdUsuario INT PRIMARY KEY IDENTITY,
IdTipoUsuario INT FOREIGN KEY REFERENCES TipoDeUsuario(IdTipoUsuario) NOT NULL,
IdClinica INT FOREIGN KEY REFERENCES Clinica(IdClinica) NOT NULL,
EmailUsuario VARCHAR(30) NOT NULL UNIQUE,
SenhaUsurario VARCHAR(8) NOT NULL,
Nome VARCHAR(40) NOT NULL
);

CREATE TABLE [Medico]
(
IdMedico INT PRIMARY KEY IDENTITY,
IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) NOT NULL,
IdEspecialidade INT FOREIGN KEY REFERENCES Especialidade(IdEspecialidade) NOT NULL,
CRM VARCHAR(14) NOT NULL UNIQUE
);

CREATE TABLE [Paciente]
(
IdPaciente INT PRIMARY KEY IDENTITY,
IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) NOT NULL,
CPF VARCHAR(11) NOT NULL UNIQUE
);

CREATE TABLE [Consulta]
(
IdConsulta INT PRIMARY KEY IDENTITY,
IdClinica INT FOREIGN KEY REFERENCES Clinica(IdClinica) NOT NULL,
IdMedico INT FOREIGN KEY REFERENCES Medico(IdMedico) NOT NULL,
IdPaciente INT FOREIGN KEY REFERENCES Paciente(IdPaciente) NOT NULL,
DataConsulta VARCHAR(15) NOT NULL,
Descricao VARCHAR(100) NOT NULL
);

CREATE TABLE [Comentario]
(
IdComentario INT PRIMARY KEY IDENTITY,
IdConsulta INT FOREIGN KEY REFERENCES Consulta(IdConsulta) NOT NULL,
Feedback VARCHAR(200) NOT NULL
);


