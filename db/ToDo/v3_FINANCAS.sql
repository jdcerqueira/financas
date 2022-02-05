USE [FINANCAS]
GO

IF OBJECT_ID('lancamentos.seqLancamento','SO') IS NOT NULL
	DROP SEQUENCE lancamentos.seqLancamento
GO

CREATE SEQUENCE lancamentos.seqLancamento AS INT
	START WITH 1
	INCREMENT BY 1
	MINVALUE 1
	NO MAXVALUE
	CYCLE
	CACHE 100
GO

IF OBJECT_ID('dbo.Movimentacao','U') IS NOT NULL
	DROP TABLE dbo.Movimentacao
GO

IF OBJECT_ID('dbo.Lancamento','U') IS NOT NULL
	DROP TABLE dbo.Lancamento
GO

CREATE TABLE dbo.Lancamento
(
	cdLancamento	INT				NOT NULL,
	dsLancamento	VARCHAR(70)		NOT NULL,
	dsResponsavel	VARCHAR(100)	NOT NULL,
	flFixo			BIT				NOT NULL,
	qtParcelas		INT				NOT NULL,
	valorSugerido	DECIMAL(18,2)	NOT NULL,
	flQuitado		BIT				NOT NULL,
	CONSTRAINT PKLancamento01 PRIMARY KEY(cdLancamento)
)
GO

CREATE TABLE dbo.Movimentacao
(
	dataHoraMovimentacao	DATETIME		NOT NULL,
	cdLancamento			INT				NOT NULL,
	valorMovimentacao		DECIMAL(18,2)	NOT NULL,
	nuParcela				INT				NOT NULL,
	flQuitado				BIT				NOT NULL,
	CONSTRAINT PKMovimentacao01 PRIMARY KEY(dataHoraMovimentacao,cdLancamento),
	CONSTRAINT FKLancamento_Movimentacao01 FOREIGN KEY(cdLancamento) REFERENCES dbo.Lancamento(cdLancamento)
)
GO