# .NET Web API Demo Project

Este proyecto es una aplicación de demostración creada para aprender los conceptos fundamentales de ASP.NET Core Web API.

## Objetivos de aprendizaje

Este proyecto permite aprender sobre:

1. **Parámetros en métodos** - Uso de atributos como `[FromBody]`, `[FromQuery]`, `[FromRoute]`, etc.
2. **Enrutamiento** - Configuración de rutas para los diferentes endpoints de la API
3. **Controladores** - Creación y organización de controladores RESTful
4. **Tipos de retorno** - Uso de `ActionResult` y otras clases de respuesta HTTP
5. **Patrón Repositorio** - Implementación de una capa de abstracción para el acceso a datos
6. **Contexto de datos** - Configuración y uso de Entity Framework Core con DbContext
7. **Modelos** - Definición de entidades y relaciones
8. **DTOs (Data Transfer Objects)** - Separación de las entidades de dominio de los objetos de transferencia
9.  **Seeders** - Inicialización de datos para pruebas y desarrollo
10. **Generación de datos falsos** - Uso de la biblioteca Bogus para crear datos de prueba realistas

## Estructura del proyecto

```
dotnet-web-api/
├── Src/
│   ├── Controllers/       # Controladores de la API
│   ├── Data/              # Contexto de datos y configuración de EF Core
│   ├── DTOs/              # Objetos de transferencia de datos
│   ├── Interfaces/        # Interfaces para el patrón repositorio
│   ├── Models/            # Entidades y modelos de dominio
│   └── Repositories/      # Implementaciones del patrón repositorio
├── .gitignore             # Archivo de configuración para Git
├── Program.cs             # Punto de entrada de la aplicación
└── README.md              # Este archivo
```

## Modelos implementados

El proyecto incluye varios modelos principales:

- **Product**: Productos con sus características básicas
- **Store**: Tiendas que tienen productos
- **Assistant**: Un ejemplo simple de controlador con operaciones CRUD en memoria

## Características de la API

### Controlador de Productos

- Obtener todos los productos
- Obtener un producto por ID
- Filtrar productos por rango de precio
- Buscar productos por término
- Obtener productos por tienda
- Agrupar productos por tienda
- Obtener el producto más caro

### Controlador de Tiendas

- Obtener todas las tiendas con información básica
- Obtener una tienda con sus productos
- Obtener productos específicos de una tienda
- Buscar tiendas por nombre

### Controlador de Asistentes (ejemplo en memoria)

- Obtener todos los asistentes (con filtrado opcional)
- Obtener un asistente por ID
- Crear un nuevo asistente
- Actualizar un asistente existente
- Eliminar un asistente

## Patrón Repositorio

El proyecto implementa el patrón repositorio para separar la lógica de acceso a datos de los controladores:

- **Interfaces**: Definen los métodos disponibles (ejemplo: `IProductRepository`)
- **Implementaciones**: Contienen la lógica de acceso a datos usando Entity Framework Core

## Configuración y ejecución

### Requisitos previos

- .NET 8.0 SDK o superior
- Un IDE como Visual Studio o VS Code

### Pasos para ejecutar

1. Clonar el repositorio
2. Navegar al directorio del proyecto
3. Ejecutar `dotnet restore` para restaurar las dependencias
4. Ejecutar `dotnet ef database update` para aplicar las migraciones
5. Ejecutar `dotnet run` para iniciar la aplicación

La API estará disponible en `http://localhost:5000`.

## Tecnologías utilizadas

- ASP.NET Core 8.0
- Entity Framework Core
- SQLite (base de datos local)
- Bogus (para generación de datos de prueba)