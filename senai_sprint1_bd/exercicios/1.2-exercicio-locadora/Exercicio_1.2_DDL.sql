CREATE DATABASE Exercicio_1_2;

USE Exercicio_1_2;

CREATE TABLE Cliente
(
	IdCliente INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(20) NOT NULL,
	Cpf VARCHAR(12) NOT NULL UNIQUE
);

CREATE TABLE Modelo 
(
	IdModelo INT PRIMARY KEY IDENTITY,
	Marca VARCHAR(10) NOT NULL,
	Nome VARCHAR(15) NOT NULL
);

CREATE TABLE Empresa
(
	IdEmpresa INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(20) NOT NULL

);


CREATE TABLE Veiculo
(
	IdVeiculo INT PRIMARY KEY IDENTITY,
	IdEmpresa INT FOREIGN KEY REFERENCES Empresa(IdEmpresa) NOT NULL,
	IdModelo INT FOREIGN KEY REFERENCES Modelo(IdModelo) NOT NULL,
	Placa VARCHAR(15) NOT NULL UNIQUE
);

CREATE TABLE Aluguel
(
	IdAluguel INT PRIMARY KEY IDENTITY,
	IdVeiculo INT FOREIGN KEY REFERENCES Veiculo(IdVeiculo) NOT NULL,
	IdCliente INT FOREIGN KEY REFERENCES Cliente(IdCliente) NOT NULL,
	Protocolo VARCHAR(20) NOT NULL UNIQUE
);

