USE BdiExamen;
GO

CREATE PROCEDURE spAgregar
	@Nombre VARCHAR(255),
	@Descripcion VARCHAR(255),
	@CodigoRetorno INT OUTPUT,
	@Mensaje VARCHAR(255) OUTPUT
AS
BEGIN
	BEGIN TRY
		INSERT INTO tblExamen (Nombre, Descripcion)
		VALUES (@Nombre, @Descripcion);
				
		SET @CodigoRetorno = 0
		SET @Mensaje = 'Registro insertado satisfactoriamente';		
	END TRY

	BEGIN CATCH
		SET @CodigoRetorno = ERROR_NUMBER();
		SET @Mensaje = ERROR_MESSAGE();
	END CATCH
END;