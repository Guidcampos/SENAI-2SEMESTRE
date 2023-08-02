USE Exercicio_1_2

INSERT INTO Cliente (Nome,Cpf)
VALUES ('Guilherme', 1234), ('Gustavo',12345),('Gabriel', 123456)

SELECT * FROM Cliente;

INSERT INTO Modelo(Marca,Nome)
VALUES ('BMW','X1'), ('FORD','Mustang'), ('FORD','Fiesta')

SELECT * FROM Modelo;

INSERT INTO Empresa(Nome)
VALUES('MATRIZ')

SELECT * FROM Empresa

INSERT INTO Veiculo(IdEmpresa,IdModelo,Placa)
VALUES (1,2,'123XR'),(1,1,'321XR'),(1,2,'321RX'), (1,3,'123RX')

SELECT * FROM Veiculo

INSERT INTO Aluguel(IdVeiculo, IdCliente, Protocolo)
VALUES (2,3,'ASDIND5155'), (1,2,'OASDPLPSA'), (3,1,'QWOKPD51151')

SELECT * FROM Aluguel

SELECT * FROM Cliente;
SELECT * FROM Modelo;
SELECT * FROM Empresa;
SELECT * FROM Veiculo;
SELECT * FROM Aluguel;