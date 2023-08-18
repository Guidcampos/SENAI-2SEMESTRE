-- DML INSERINDO DADOS



INSERT INTO TipoDeUsuario(TituloTipoUsuario)
VALUES ('medico'), ('paciente')

INSERT INTO Clinica
VALUES ('Health clinic', 'Rua Niteroi 180', '584728182882887', 'Health Clinic S.A')

INSERT INTO Usuario
VALUES (1, 1, 'guilherme@hotmail.com', '1234', 'Guilherme Campos'), (2, 1, 'jose@hotmail.com', '1243', 'Jose Carlos'), (1, 1, 'edu@senai.com', '532', 'Eduardo costa'), (2, 1, 'roque@hotmail.com', '321', 'Carlos roque')

INSERT INTO Especialidade(TituloEspecialidade)
VALUES ('cardiologista'), ('fisioterapeuta')

INSERT INTO Medico
VALUES (5, 1, '82818484255288'), (7, 2, '12345678')

INSERT INTO Paciente
VALUES (6, '39905572899'), (8, '2310658057')

INSERT INTO Consulta
VALUES (1, 1, 1, '16/08/2023', 'fortes dores no peito'), (1, 3, 2, '16/08/2023', 'dores no ombro')

INSERT INTO Comentario
VALUES (1, 'medico atencioso, me passou remedios'), (2, 'a consulta foi feita de forma correta')



