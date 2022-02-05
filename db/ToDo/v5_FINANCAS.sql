USE [FINANCAS]
GO

IF OBJECT_ID('lancamentos.criaLancamento') IS NOT NULL
	DROP PROCEDURE lancamentos.criaLancamento
GO

/*
* lancamentos.criaLancamento
* Cria um lançamento
* 05-02-2022
* JD
*/
CREATE PROCEDURE lancamentos.criaLancamento
	@dsLancamento	VARCHAR(70),
	@dsResponsavel	VARCHAR(100),
	@flFixo			BIT,
	@qtParcelas		INT,
	@valorSugerido	DECIMAL(18,2),
	@flQuitado		BIT
AS
BEGIN
	SET TRANSACTION ISOLATION LEVEL SNAPSHOT
	SET NOCOUNT ON

	DECLARE @ErrorMessage	VARCHAR(500)
	DECLARE @ErrorNumber	INT
	DECLARE @ErrorState		SMALLINT
	DECLARE @ErrorSeverity	SMALLINT

	BEGIN TRAN

	DECLARE @cdLancamento INT = (NEXT VALUE FOR lancamentos.seqLancamento)

	BEGIN TRY
		INSERT INTO dbo.Lancamento
			(cdLancamento,dsLancamento,dsResponsavel,flFixo,qtParcelas,valorSugerido,flQuitado)
		VALUES
			(@cdLancamento,@dsLancamento,@dsResponsavel,@flFixo,@qtParcelas,@valorSugerido,@flQuitado)

		COMMIT
		SELECT 0 Retorno
	END TRY
	BEGIN CATCH
		ROLLBACK

		SELECT 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorNumber = ERROR_NUMBER(),
			@ErrorState = ERROR_STATE(),
			@ErrorSeverity = ERROR_SEVERITY()

		RAISERROR (@ErrorMessage,@ErrorSeverity,@ErrorState,N'',@ErrorNumber)
	END CATCH

	SET NOCOUNT OFF
END
GO