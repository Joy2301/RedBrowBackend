# Prueba Tecnica RedBrow - Johnny Rondon
## Backend

Como se me especifico via correo, esta prueba consiste en un CRUD sencillo para registrar **usuarios**, verlos, actualizarlas o eliminarlos.

Haciendo uso de **C# .NET 7.0, SQLServer y EntityFrameworkCore.**

## Ejecutar la aplicacion
### Opcion 1

- Se tiene la opcion de descargar la imagen de **Docker** y correrla ejecutando el comando:

**`docker run --name RedBrowBack -p 80:80 -p 443:443  -d joy2301/redbrowbackend:latest`**

(Debe tener **Docker Desktop** ejecutandose en su maquina)

Con esto ya habremos construido la imagen de la aplicacion, si va a su **Docker Desktop** o ejecuta el comando **`docker ps -a`** en su linea de comandos, podra ver la imagen creada con el nombre **"RedBrowBack"** ejecutandose por el puerto 80 y 443

#### Metodos de la API
> Get Paginado:
http://localhost:80/api/Users/paginated?orden=Id&tipo_orden=DESC&pagina=1&registros_por_pagina=10

> Get Todos los usuarios:
http://localhost:80/api/Users/

>Get UN solo usuario:
http://localhost:80/api/Users/1

> Post un usuario.. Enviar un JSON como el de debajo:
http://localhost:80/api/Users/

```json
{
  "id": 0,
  "firstName": "Yordi",
  "lastName": "Bello",
  "email": "YBello@hotmail.com",
  "age": "25",
  "country": "MEXICO"
}
```

> //PUT un usuario.. Enviar un JSON como el de debajo:
http://localhost:80/api/Users?id=3

```json
{
  "id": 3,
  "firstName": "Franklyn",
  "lastName": "Terrero",
  "email": "Fterrero@hotmail.com",
  "age": "25",
  "country": "MEXICO"
}
```

> Elimnar un usuario:
http://localhost:80/api/Users?id=3


### Opcion 2
- Otra opcion para ejecutar la aplicacion es clonar o descargar el repositorio, abrir la solucion en el IDE Visual Studio y ejecutarla.
`<link>` : <https://github.com/Joy2301/RedBrowBackend>

**Nota**: La **base de datos** ya esta almacenada en un **hosting** por lo que no es necesario correr ningun script para agregarla.
