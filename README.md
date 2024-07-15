# Examen
# Notas

1.- La cadena de conexion "DefaultConnection" fue modificada segun el nombre del server del examen, respete nombre de tablas

2.- En el proyecto API se encuentran todos los stored procedures para poder crearlos, spAgregar, spActualizar, spConsultar, spEliminar, spCrearTablaYBd adicionalmente agregue un spSeed para insertar datos (intente crearlos en una carpeta separada pero no me dejaba)

#Paso 1 - Ejecutar todos los Stored Procedures empezando por la creacion de la base de datos

#Paso 2 - Realizar ajustes para conexion a la base de datos

#Como usar la app

Si queremos consultar y ver multiples resultados debemos de consultar un examen que tenga el mismo nombre y descripcion, si utilizan el spSeed la opcion seria 'Examen de Derecho', 'Examen de introducción al derecho' para nombre y descripcion respectivamente. Esto hara que nos muestre una tabla debajo del formulario inicial.

Los demas metodos para crear, actualizar y eliminar, si funcionan pero no agregue un error handler que pudiera mostrar los estatus del response.

Gracias por el tiempo dedicado a revisar este proyecto.


