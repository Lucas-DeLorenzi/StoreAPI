# Store API

## Descripción

La **Store API** es una API RESTful construida con **.NET Core 8** para gestionar productos y categorías con funcionalidades CRUD. Está organizada en capas y sigue los principios de CQRS para mejorar la separación de responsabilidades. La API incluye Swagger para facilitar la documentación y prueba de los endpoints.

## Estructura del Proyecto

La solución está organizada de la siguiente manera:

- **src/**
  - `Store.Api`: Contiene el controlador y la configuración de la API.
  - `Store.Application`: Contiene los servicios, DTOs y lógica de negocio.
  - `Store.Infrastructure`: Contiene la capa de persistencia y configuración de bases de datos.
  - `Store.Domain`: Define las entidades y las interfaces de los repositorios.
- **test/**
  - `Store.Application.Tests`: Contiene las pruebas unitarias para la lógica de negocio.

## Requisitos Previos

- **.NET Core 8 SDK** instalado.
- **SQL Server** configurado en tu entorno de desarrollo.

## Ejecución de la API

### 1. Configuración de la base de datos

Antes de ejecutar la API, asegúrate de configurar la cadena de conexión de la base de datos en el archivo `appsettings.json`. Debería verse algo así:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=StoreDb;Trusted_Connection=True;"
}
```
### 2. Generar migraciones y actualizar base de datos
```
Add-Migration InitialMigration -StartupProject Store.Api -Project Store.Infrastructure -OutputDir Migrations
Update-Database
```

