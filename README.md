# MovimientoCuentas
## Pre Requisitos
### Base de Datos
 - SQL Server 2017 minimo
 - Autenticacion SQL activada
 - Usuario con acceso para realizar operaciones CRUD sobre las tablas
 - Permitir conexiones remotas hacia la instancia
### SDK's
 - NET SDKs installed: 
    - 6.0.301 
### Runtimes installed:
- .NET runtimes installed:
    - Microsoft.AspNetCore.App 6.0.6 
    - Microsoft.NETCore.App 6.0.6 

## Configuracion de archivos
### ConnectionString
- En ./src/Cliente/appsettings.json contiene la configuracion de acceso a la base de datos y se debe configurar segun la forma de ejecucion.
### Postman
 - En ./scripts/postman/pruebasApi.postman_collection.json se encuentra el archivo de coleccion para realizar las pruebas sobre los endpoint


## Configuracion de BDD
### Ejecucion Scripts
1. Los scripts por defecto estan con la bdd bdd_bpichincha1, se debe tomar en cuenta es al momento de configurar los connectioString de la App
1. Ejecutar los scrips que estan en ./scripts/bdd en el orden que esta descrito en el nombre
    - 1-basedatos.sql
    - 2-indices
### Autenticacion
- Por defecto el archivo de connectioString esta configurado para usar Authn por SQL Server, si se desea Authn Integrada, se debe configurar.

## Configuracion para Docker
### Deploy
1. Se debe tener configurado el archivo Dockerfile con las configuraciones para la imagen
1. Se debe ejecutar el comando docker build -t microsprueba . 
 (donde microsprueba es el nombre de la imagen)
1. Se debe ejecutar el comando docker run -d -p 5172:80 --name webapi microsprueba (donde webapi es el nombre del container)
### Consejos
Para validar como esta corriendo la imagen podemos usar los siguientes comandos
docker ps -a

- docker ps -a para ver el estado de los contenedores
- docker rm webapi elimina el contenedor
- docker rmi GUID  elimina una imagen
- docker logs webapi para ver logs que va dejando el web api en la consola Kestrel