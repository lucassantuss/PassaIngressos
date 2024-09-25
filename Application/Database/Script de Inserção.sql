-- Inserção dos dados nas tabelas

-- core.Tabela_Geral
INSERT INTO core.Tabela_Geral (Tabela) VALUES 
('TG_SEXO'), 
('TG_TIPO_INGRESSO');

-- core.Item_Tabela_Geral
-- Sexo
INSERT INTO core.Item_Tabela_Geral (Id_Tabela_Geral, Sigla, Descricao) VALUES 
(1, 'M', 'Masculino'), 
(1, 'F', 'Feminino');

-- Tipo de Ingresso
INSERT INTO core.Item_Tabela_Geral (Id_Tabela_Geral, Sigla, Descricao) VALUES 
(2, 'PIS', 'Pista'),
(2, 'ARQ', 'Arquibancada');

-- core.Arquivo
INSERT INTO core.Arquivo (Conteudo_Arquivo, Extensao, Content_Type, Nome) VALUES 
(0x1234, 'jpg', 'image/jpeg', 'FotoPessoa1'), 
(0x5678, 'jpg', 'image/jpeg', 'FotoEvento1');

-- core.Pessoa
INSERT INTO core.Pessoa (Nome, Id_Tg_Sexo, Data_Nascimento, CPF, RG, Id_Arquivo_Foto) VALUES 
('João da Silva', 1, '1990-05-12', '12345678901', 'MG123456', 1), 
('Maria Souza', 2, '1992-07-19', '98765432109', 'SP987654', 1);

-- acesso.Perfil
INSERT INTO acesso.Perfil (Nome_Perfil, Descricao_Perfil) VALUES 
('ADMIN', 'Acesso total ao sistema'), 
('USER', 'Acesso restrito ao sistema');

-- acesso.Usuario
INSERT INTO acesso.Usuario (Login, Senha, Id_Pessoa) VALUES 
('joaosilva', 'senha123', 1), 
('mariasouza', 'senha321', 2);

-- acesso.Usuario_Perfil
INSERT INTO acesso.Usuario_Perfil (Id_Usuario, Id_Perfil) VALUES 
(1, 1), 
(2, 2);

-- core.Feedback
INSERT INTO core.Feedback (Descricao_Feedback, Id_Pessoa) VALUES 
('Ótimo sistema!', 1), 
('Gostei do evento.', 2);

-- venda.Evento
INSERT INTO venda.Evento (Nome_Evento, Local_Evento, Data_Hora_Evento, Id_Arquivo_Evento) VALUES 
('Show de Rock', 'Estádio XYZ', CONVERT(datetime, '2024-09-15 20:00:00', 120), 2), 
('Feira de Tecnologia', 'Centro de Convenções ABC', CONVERT(datetime, '2024-10-01 10:00:00', 120), 2);

-- venda.Ingresso
INSERT INTO venda.Ingresso (Id_Tg_Tipo_Ingresso, Valor, Id_Pessoa_Anunciante, Id_Evento) VALUES 
(2, 250.00, 1, 1), 
(1, 500.00, 2, 2);