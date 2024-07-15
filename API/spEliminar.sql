USE BdiExamen;
GO

CREATE PROCEDURE spEliminar
	@IdExamen INT,
	@CodigoRetorno INT OUTPUT,
	@Mensaje VARCHAR(255) OUTPUT
AS
BEGIN
	BEGIN TRY
		DELETE tblExamen		
		WHERE idExamen = @IdExamen;

		IF @@ROWCOUNT = 0
		BEGIN
			SET @CodigoRetorno = 1;
			SET @Mensaje = 'No se encontro registro con ID especificado';
		END

		ELSE
		BEGIN
			SET @CodigoRetorno = 0
			SET @Mensaje = 'Registro eliminado satisfactoriamente';
		END
	END TRY

	BEGIN CATCH
		SET @CodigoRetorno = ERROR_NUMBER();
		SET @Mensaje = ERROR_MESSAGE();
	END CATCH
END