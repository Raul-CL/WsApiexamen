CREATE PROCEDURE spActualizar
	@IdExamen INT,
	@Nombre VARCHAR(255),
	@Descripcion VARCHAR(255),
	@CodigoRetorno INT OUTPUT,
	@Mensaje VARCHAR(255) OUTPUT
AS
BEGIN
	BEGIN TRY
		UPDATE tblExamen
		SET Nombre =@Nombre, Descripcion = @Descripcion
		WHERE idExamen = @IdExamen;

		IF @@ROWCOUNT = 0
		BEGIN
			SET @CodigoRetorno = 1;	
			SET @Mensaje = 'No se encontro registro con ID especificado';
		END

		ELSE
		BEGIN
			SET @CodigoRetorno = 0
			SET @Mensaje = 'Registro actualizado satisfactoriamente';
		END
	END TRY

	BEGIN CATCH
		SET @CodigoRetorno = ERROR_NUMBER();
		SET @Mensaje = ERROR_MESSAGE();
	END CATCH
END