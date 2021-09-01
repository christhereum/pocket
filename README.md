# pocket

## Solución
La API está en .NET Core 3.1

## Base de datos
Use Sql Server 2019, dejo adjunto el archivo **pocket_scripts.sql** (dentro de carpeta Adjuntos) con los CREATE de las tablas (también drops y selects por las dudas). 
Pueden hacerlo corriendo el script o usando Add-Migration / Update-Database de la consola de administrador de paquetes de Visual Studio.

## Documentación
Link de la documentación de los métodos generada por Postman: https://documenter.getpostman.com/view/3257129/U16dSogX
También adjunto el archivo **Pocket.postman_collection.json** (dentro de carpeta Adjuntos) para importarlo directamente en Postman y testear todos los metodos de la API.

## Aclaraciones sobre el Modelo y Lógica
A fines del test, puse algunos datos tal y como se lo pide ya que no son de mucha relevancia y es solo agrandar el proyecto sin sumar complejidad.
Como por ejemplo el campo Dni que lo dejé como entero pero podría ser string documento y agregar un tipo de documento.
El monto del prestamo lo puse como un decimal 10,2 pero podría ser de otra longitud para abarcar mas posibilidades como de las crypto. 
También el porcentaje está como un entero para pero podría ser decimal para usar fracciones. Lo mismo con el sueldo que está como entero.
Con los endpoints solamente estoy haciendo los pedidos y no el CRUD completo ya que sino tendría que definir lógica, como si es borrado lógico o físico y agregar todos los campos de bitacora.
El ID Adelanto lo estoy generando como se solicita aunque esto rompa con las formas normales de base de datos, lo mejor sería utilizar un ID numérico o en todo caso un GUID, pero a fines del test lo mantuve asi.
