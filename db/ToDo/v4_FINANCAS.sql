USE [FINANCAS]
GO

IF OBJECT_ID('lancamentos.listaMovimentacaoPorPeriodo') IS NOT NULL
	DROP PROCEDURE lancamentos.listaMovimentacaoPorPeriodo
GO

/*
* lancamentos.listaMovimentacaoPorPeriodo
* Lista a movimenta��o dos lan�amentos dentro de um determinado per�odo
* 05-02-2022
* JD
*/
CREATE PROCEDURE lancamentos.listaMovimentacaoPorPeriodo
	@dataHoraMovimentacaoIni DATETIME,
	@dataHoraMovimentacaoFim DATETIME
AS
BEGIN
	SET TRANSACTION ISOLATION LEVEL SNAPSHOT
	SET NOCOUNT ON

	SELECT
		dataHoraMovimentacao,
		cdLancamento,
		valorMovimentacao,
		nuParcela,
		flQuitado
	FROM dbo.Movimentacao
	WHERE
		dataHoraMovimentacao BETWEEN @dataHoraMovimentacaoIni AND @dataHoraMovimentacaoFim

	SET NOCOUNT OFF
END
GO