CREATE DATABASE [Votaciones];
GO

USE [Votaciones];
GO

CREATE TABLE [dbo].[Partidos] (
    [IDPartido] INT PRIMARY KEY IDENTITY(1,1),
    [NombrePartido] VARCHAR(50) NOT NULL
);

CREATE TABLE [dbo].[Candidatos] (
    [IDCandidato] INT PRIMARY KEY IDENTITY(1,1),
    [NombreCandidato] VARCHAR(50) NOT NULL,
    [ApellidoCandidato] VARCHAR(50) NOT NULL,
    [NumeroTelefono] VARCHAR(8) NOT NULL,
    Plataforma VARCHAR(100),
    [IDPartido] INT NOT NULL,
    CONSTRAINT FK_Candidatos_Partidos FOREIGN KEY ([IDPartido]) REFERENCES [dbo].[Partidos]([IDPartido])
);

CREATE TABLE [dbo].[Votos] (
    [IDVoto] INT PRIMARY KEY IDENTITY(1,1),
    [IDCandidato] INT NOT NULL,
    [FechaVoto] DATETIME NOT NULL,
    CONSTRAINT FK_Votos_Candidatos FOREIGN KEY ([IDCandidato]) REFERENCES [dbo].[Candidatos]([IDCandidato]),
);


CREATE TABLE Resultados (
    IDResultado INT PRIMARY KEY IDENTITY(1,1),
    IDCandidato INT NOT NULL,
    TotalVotos INT NOT NULL,
    CONSTRAINT FK_Resultados_Candidatos FOREIGN KEY (IDCandidato) REFERENCES Candidatos(IDCandidato)
);

  INSERT INTO [dbo].[Partidos] (NombrePartido) VALUES ('Frente Amplio');
  INSERT INTO [dbo].[Partidos] (NombrePartido) VALUES ('Partido Liberacion Nacional');
