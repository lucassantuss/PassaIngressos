-- Criação do DB
CREATE DATABASE db_PassaIngressos
USE db_PassaIngressos

-- Criação dos Schemas das Tabelas
CREATE SCHEMA acesso
CREATE SCHEMA core
CREATE SCHEMA venda

-- Criação das tabelas
CREATE TABLE core.Arquivo (
    Id_Arquivo INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Conteudo_Arquivo VARBINARY(MAX) NOT NULL,
    Extensao VARCHAR(5) NULL,
    Content_Type VARCHAR(100) NULL,
    Nome VARCHAR(8000) NULL
);

CREATE TABLE core.Tabela_Geral (
    Id_Tabela_Geral INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Tabela VARCHAR(50) NOT NULL
);

CREATE TABLE core.Item_Tabela_Geral (
    Id_Item_Tabela_Geral INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Id_Tabela_Geral INT,
    Sigla VARCHAR(50),
    Descricao VARCHAR(200),
    CONSTRAINT FK_Item_Tabela_Geral FOREIGN KEY (Id_Tabela_Geral) REFERENCES core.Tabela_Geral(Id_Tabela_Geral)
);

CREATE TABLE core.Pessoa (
    Id_Pessoa INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Nome VARCHAR(100) NOT NULL,
    Id_Tg_Sexo INT,
    Data_Nascimento DATE,
    CPF VARCHAR(11),
    RG VARCHAR(15),
    Id_Arquivo_Foto INT,
    CONSTRAINT FK_Id_Tg_Sexo FOREIGN KEY (Id_Tg_Sexo) REFERENCES core.Item_Tabela_Geral(Id_Item_Tabela_Geral),
    CONSTRAINT FK_Id_Arquivo_Foto FOREIGN KEY (Id_Arquivo_Foto) REFERENCES core.Arquivo(Id_Arquivo)
);

CREATE TABLE acesso.Perfil (
    Id_Perfil INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Nome_Perfil VARCHAR(50) NOT NULL,
    Descricao_Perfil VARCHAR(200)
);

CREATE TABLE acesso.Usuario (
    Id_Usuario INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Login VARCHAR(100) NOT NULL,
    Senha VARCHAR(100) NOT NULL,
    Id_Pessoa INT,
    CONSTRAINT FK_Usuario_Pessoa FOREIGN KEY (Id_Pessoa) REFERENCES core.Pessoa(Id_Pessoa)
);

CREATE TABLE acesso.Usuario_Perfil (
    Id_Usuario_Perfil INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Id_Usuario INT,
    Id_Perfil INT,
    CONSTRAINT FK_Usuario_Perfil_Usuario FOREIGN KEY (Id_Usuario) REFERENCES acesso.Usuario(Id_Usuario),
    CONSTRAINT FK_Usuario_Perfil_Perfil FOREIGN KEY (Id_Perfil) REFERENCES acesso.Perfil(Id_Perfil)
);

CREATE TABLE core.Feedback (
    Id_Feedback INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Descricao_Feedback VARCHAR(500),
    Id_Pessoa INT,
    CONSTRAINT FK_Feedback_Pessoa FOREIGN KEY (Id_Pessoa) REFERENCES core.Pessoa(Id_Pessoa)
);

CREATE TABLE venda.Evento (
    Id_Evento INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Nome_Evento VARCHAR(100),
    Local_Evento VARCHAR(200),
    Data_Hora_Evento DATETIME,
    Id_Arquivo_Evento INT,
    CONSTRAINT FK_Id_Arquivo_Evento FOREIGN KEY (Id_Arquivo_Evento) REFERENCES core.Arquivo(Id_Arquivo)
);

CREATE TABLE venda.Ingresso (
    Id_Ingresso INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Id_Tg_Tipo_Ingresso INT,
    Valor DECIMAL(10, 2),
    Id_Pessoa_Anunciante INT,
    Id_Pessoa_Comprador INT,
    Id_Evento INT,
    CONSTRAINT FK_Ingresso_Tipo_Ingresso FOREIGN KEY (Id_Tg_Tipo_Ingresso) REFERENCES core.Item_Tabela_Geral(Id_Item_Tabela_Geral),
    CONSTRAINT FK_Ingresso_Anunciante FOREIGN KEY (Id_Pessoa_Anunciante) REFERENCES core.Pessoa(Id_Pessoa),
    CONSTRAINT FK_Ingresso_Comprador FOREIGN KEY (Id_Pessoa_Comprador) REFERENCES core.Pessoa(Id_Pessoa),
    CONSTRAINT FK_Ingresso_Evento FOREIGN KEY (Id_Evento) REFERENCES venda.Evento(Id_Evento)
);