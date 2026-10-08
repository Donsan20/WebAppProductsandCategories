# Instrucciones para la Base de Datos (SQL Server)

Este directorio contiene el script necesario para recrear la base de datos `SampleDb` en cualquier computador nuevo.

## Pasos para ejecutar el script:

1. **Abrir SQL Server Management Studio (SSMS)** o Azure Data Studio.
2. Conectarse a la instancia de SQL Server (por ejemplo: `(localdb)\MSSQLLocalDB`, `localhost` o `.\SQLEXPRESS`).
3. Abrir el archivo `init_database.sql` en SSMS (**Archivo > Abrir > Archivo...**).
4. Presionar la tecla **F5** o hacer clic en el botón **Execute (Ejecutar)**.

El script se encargará automáticamente de:
- Crear la base de datos `SampleDb`.
- Crear la tabla `Categories`.
- Crear la tabla `Products` con su llave foránea (`FK`).
- Insertar los registros iniciales de prueba en español.
