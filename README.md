# Trabajo Práctico 3 - Grupo 4

## 🏨 Agencia de Viajes 🏨

Mediante la implementación del apartado visual tenemos como primer form una interfaz de logeo, de registro y recuperar contraseña en el que se muestran estos 3 apartados:

* Login:
En la interfaz de logeo tenemos la opción de ingresar con nuestro DNI (no permite caracteres alfabéticos, sólo numéricos) y una contraseña que previamente habremos puesto en el registro. El usuario registrado tendrá 3 intentos para realizar un login de manera correcta, si estos 3 intentos no se realizan de manera satisfactoria el usuario con el que se está intentando ingresar será bloqueado y solo un administrador podrá realizar el desbloqueo. 

* Cambiar contraseña:
En caso de no recordar la contraseña debajo del botón LOGIN se encuentra una opción de recuperación que nos permitirá cambiarla colocando los datos de usuario: dni, contraseña nueva y repetir contraseña.

* Registro:
En la interfaz de Registro tenemos 4 campos a completar:
  * Dni (En este campo solo se aceptan valores numéricos)
  * Nombre
  * Contraseña
  * Mail
Dentro de este apartado se encuentra un checkbox (¿Es Admin?) que nos permite a los administradores crear un usuario admin desde la interfaz de registro.


## 👤 Vista Usuario 👤:
Una vez logeados: 
- En la parte superior se podrá ver el nombre de la persona conectada.
- En la parte inferior izquierda tenemos un botón para cerrar sesión. 
- En la parte izquierda de la aplicación Se pueden ver 3 opciones, la opción de Buscador, Ver Alojamientos y Mis Reservas:
* Buscador: En esta opción se encuentran los filtros "Buscar por ciudad", "Fecha de ida" y "Fecha de vuelta" para reservar rápidamente.
* Ver Alojamientos: Dentro de esta opción podremos elegir los distintos tipos de alojamientos que nos ofrece la aplicación. Tenemos distintas herramientas para realizar filtrados para nuestras preferencias, entre estos filtrados están: 
  
  * Tipo: Hoteles, Cabañas o las dos opciones juntas.
  * Ciudad: Las diferentes ciudades a elegir.
  * Barrio: Los diferentes barrios a elegir.
  * Precio min: Se puede colocar un precio minimo para el filtrado.
  * Precio max: Se puede colocar un precio maximo para el filtrado.
  * Estrella: La cantidad de estrellas de los hoteles.
  * Personas: La cantidad de personas para el alojamiento.

  Una vez completadas estas opciones a la derecha se encuentra un botón filtrar que ejecuta estas preferencias y nos lo muestra en un grid view en la parte inferior de la app.

  Debajo de las opciones de filtrado encontramos el apartado fechas que nos permite elegir la cantidad de días que queremos reservar el alojamiento. Hay 2 opciones:
  
  * Fecha de ida: En la fecha de ida colocaremos el día en el que llegaremos al alojamiento 
  * Fecha de vuelta: En la fecha de vuelta colocaremos el día en el que nos iremos del alojamiento
  Para esto se nos va a abrir un panel tipo calendario en donde podremos marcar día, mes y año.

  En la parte derecha del apartado Fechas se encuentra la opción de Ordenar por. Aquí podremos ordenar la búsqueda ya sea por: 
   * Por defecto
   * Por código
   * Personas
   * Estrellas
  
  Este ordenamiento se realiza de menor a mayor

  Por ultimo tenemos el Grid View en donde se nos muestra todas las opciones que tenemos para reservar con la información de cada una de ellas:
   * Código
   * Ciudad
   * Barrio 
   * Estrellas
   * Cantidad de personas
   * TV
   * Precio 

   Al lado de estas opciones se encuentra un botón de color verde que dice Reservar para realizar la reservación de la misma. 

  Una vez terminada la Reservación, la otra opción antes mencionada, Mis reservaciones, Nos mostrara las reservaciones realizadas por el usuario que esté conectado detallándose en un Grid los siguientes datos: 
  * Código de Reservación
  * Fecha de inicio
  * Fecha de fin
  * Precio

  En caso de querer cancelar una o algunas de las reservaciones, en la parte derecha de cada una se encuentra un botón en color rojo con la palabra Cancelar que nos permitirá cancelar la misma.
 
 ## 👑 Vista Admin 👑:
En el caso de la vista del administrador tenemos las mismas opciones en la parte izquierda de la aplicación nada más que se le agrega otra opción que es la de usuarios y se cambian ciertas funciones de las opciones Alojamientos y Reservas.

- En la opción Alojamientos ahora se nos despliegan 2 opciones más que estas son:
  * Hoteles
  * Cabañas

Dentro de estas opciones nos podemos encontrar con los alojamientos registrados en cada una de ellas y tenemos la posibilidad de Agregar, Modificar o Eliminar dichos alojamientos.

Para realizar alguna de estas tres opciones se debe realizar lo siguiente:

 * Agregar: 
   En la parte superior media se encuentran unos campos para completar con la información del alojamiento que queremos agregar, estos campos son:
   * Código
   * Ciudad
   * Barrio
   * Cantidad de personas
   * Estrellas
   * ¿Tiene tv?
   * Precio por día
   * Habitaciones
   * Baños

   Una vez completado dicho formulario se debe presionar el botón Agregar para incluirlo en el listado de alojamientos a reservar

 * Modificar:
   Para modificar un alojamiento ya registrado se debe seleccionar cual es el que se quiere modificar y en la parte derecha en el grid se encuentra un botón con el nombre Modificar, una vez presionado aparecerá un cartel para confirmar si realmente queremos modificar dicho alojamiento, si la respuesta es sí, los datos de ese alojamiento se cargaran al formulario de la parte de arriba en donde se hará dicha modificación (el único de dato que no se puede modificar es el código de alojamiento), una vez terminado el cambio, se deberá pulsar el botón Modificar para cargar los nuevos datos al alojamiento que se quiso modificar.

 * Eliminar:
   Muy parecido al botón modificar, el botón borrar se encuentra en el Grid de los alojamientos con un color rojo, este nos servirá para eliminar el alojamiento seleccionado del registro de alojamientos.

 En el apartado Reservas:
 Se muestran todas las reservas hechas por los usuarios registrados en la aplicación. En este mismo vamos a tener la posibilidad de Modificar o Borrar dichas reservas de la misma manera que se hace con los alojamientos. En el apartado modificar el único dato que se puede cambiar es la fecha de reserva.

 En la opción Usuarios:
 Aparecen todos los usuarios registrados en la aplicación y tendremos las mismas opciones antes mencionadas, Modificar y Borrar.
  En la opción Modificar, en este caso, podremos cambiar todos los datos y a su vez se podrá realizar el cambio de tipo de usuario de Usuario común a Usuario administrador, además, desde esta opción es donde se podrá realizar el desbloqueo de los usuarios que hayan sido bloqueados por haberse logeado de manera incorrecta más de 3 veces seguidas. 


## Integrantes ✒️

* **Zarate Miranda Saul Denis** - *Desarrollador*
* **Bossio Alberto Federico** - *Desarrollador*
* **Toyama Rodrigo** - *Desarrollador*
* **Mandirola Gabriel Nicolas** - *Desarrollador*
* **Fornes Ezequiel Christian** - *Desarrollador*
* **Ramos Lautaro Agustin** - *Desarrollador*
