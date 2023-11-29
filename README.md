# redbrow-technical-test API

Este proyecto es una API de gestión de usuarios en al cual se pueden realizar operaciones CRUD (crear, editar, eliminar y obtener información sobre usuarios)
El proyecto utiliza Docker y Docker Compose para facilitar la configuración del entorno de desarrollo. Se usa autnticación con JWT para brindar acceso autorizado 
a los métodos expuestos.

## 2. Solución

Se toma la decisión de trabajar la solución siguiendo los principios de Clean Architecture en .NET 7. 
El principal objetivo de esta arquitectura es la capacidad de separar el código en sus diferentes responsabilidades, hacer el código mucho más entendible en el presente y futuro, testeable y fácil de integrar.


## 2.1 Tecnologías
* NET 7 / C#
* ASP.NET Core 7
* Sql Server
* Entity Framework Core 7
* JWT
* MediatR
* CQRS
* AutoMapper
* Docker
* Visual studio Comunity 2022

## Requisitos Previos
Asegúrate de tener Docker y Docker Compose instalados en tu máquina antes de comenzar.

## Instrucciones para Ejecutar APi (Carpeta BackEnd)

### Paso 1: Configurar la Base de Datos
1. Navega a la carpeta "BackEnd\redbrow-technical-test\docker-image-bd" en el directorio del proyecto.
2. Ejecuta el siguiente comando para cargar la imagen de Sql Server usando Docker Compose:
   ```bash
   docker-compose up -d
2. Eejutar el script contenido en el archivo llamdo ###redbrow-db.sql para crear la base de datos del proyecto y la tabla de usuarios.

### Paso 2: Ejecucion del proyecto
1. Una vez se tenga la apicación en visual studio y haya sido ejecutada, se debe generar un token de acceso con los datos Usuario: gustavoamoreno@outlook.com -- > Password: 0123456789, este es el unico usuario parametrizado. Lo anterior se indica en la documentacoin del Swagger


## Instrucciones para Ejecutar FRONT (Carpeta FrontEnd)

Este proyecto hace uso del Api para realizar las operaciones CRUD mencionadas anterioemente

### Requisitos Previos

1. Asegúrate de tener Node.js y npm instalados en tu máquina.

### Configuración y Ejecución del Frontend (React)

1. Navega a la raíz del proyecto.

2. Ejecuta el siguiente comando para instalar las dependencias del frontend:

    ```bash
    npm install
    ```

3. Luego, ejecuta el siguiente comando para iniciar la aplicación React:

    ```bash
    npm start
    ```

4. Abre tu navegador y accede a `http://localhost:3000` para ver la aplicación en acción.

### Usuario de Prueba para Autenticación

- Usuario: `gustavoamoreno@outlook.com`
- Contraseña: `0123456789`

## Características del Proyecto

- **Autenticación JWT:** La aplicación utiliza JWT para autenticar a los usuarios. Un token JWT se obtiene al iniciar sesión con las credenciales proporcionadas.
- **Operaciones CRUD de Usuarios:** La aplicación permite crear, leer usuarios a través de la API.


