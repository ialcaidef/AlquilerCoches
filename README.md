# Alquiler Coches

Ejemplo apiRest para alquiler de coches 
El desarrollo está realizado en .NET Core 3.1

## CRUD
Para simular el trabajo que se realizaria sobre una Base de Datos, inicialmente se ha cargado en memoria un array de objetos  
sobre los cuales se pueden añadir más datos, consultar, actualizar y borrar mediantes los endpoints expuestos por el api.

#### EndPoints expuestos
**Inventario**  

Devuelve un listado de todos los coches existentes  

**Inventario/matrícula**  
Muestra los datos correspondientes a un coche realizando la búsqueda por su matrícula  

**PrecioAlquilerCoche/matrícula**  
Devuelve el precio del alquiler del coche correspondiente al tipo de coche y dias de alquiler  

**PrecioAlquilerCoches/matrículas**  
__¡¡¡ En construcción !!!__  

**PuntosFidelidad/dni**  
__¡¡¡ En construcción !!!__  

**PreciosDiasExtra/matrícula**  
Devuelve el precio que debería pagar un cliente por tener más días el coche de lo contratado inicialmente  

#### Funciones expuestas
**Post**  
Permite crear un nuevo registro  

**Put**  
Permite actualizar los datos de un registro  

**Delete**  
Permite el borrado de un registro


#### Funciones primarias:
~~~
Consulta inventario de coches
Cálculo precio del alquiler
~~~



__¡¡¡ En construcción !!!__
