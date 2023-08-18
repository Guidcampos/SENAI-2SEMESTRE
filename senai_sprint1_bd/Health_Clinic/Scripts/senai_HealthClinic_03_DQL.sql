-- DQL CONSULTA NO BANCO 

--Criar script que exiba os seguintes dados:

-- Id Consulta
-- Data da Consulta
-- Horario da Consulta
-- Nome da Clinica
-- Nome do Paciente
-- Nome do Medico
-- Especialidade do Medico
-- CRM
-- Prontuário ou Descricao
-- FeedBack(Comentario da consulta)

-- Criar função para retornar os médicos de uma determinada especialidade

SELECT * FROM Consulta

Select 
	Consulta.IdConsulta AS Consulta,
	Consulta.DataConsulta AS Data,
	Clinica.NomeFantasia AS Clinica,
	P.Nome AS Paciente,
	Paciente.CPF AS CPF,
	M.Nome AS Medico,
	Especialidade.TituloEspecialidade AS Especialidade,
	Medico.CRM AS CRM,
	Consulta.Descricao AS Prontuario,
	Comentario.Feedback AS Feedback

from Consulta
INNER JOIN Clinica ON Clinica.IdClinica = Consulta.IdClinica
INNER JOIN Paciente ON Paciente.IdPaciente = Consulta.IdPaciente
INNER JOIN Usuario P ON Paciente.IdUsuario = P.IdUsuario
INNER JOIN Medico ON Medico.IdMedico = Consulta.IdMedico
INNER JOIN Usuario M ON Medico.IdUsuario = M.IdUsuario 
INNER JOIN Especialidade ON Medico.IdEspecialidade = Especialidade.IdEspecialidade
INNER JOIN Comentario ON Comentario.IdConsulta = Consulta.IdConsulta
