# Pokedex Kanto Entity Framework

Este proyecto utiliza Entity Framework para crear una base de datos para Pokémon y sus tipos, estableciendo una relación de muchos a muchos entre ellos. El primer paso implica cargar la base de datos utilizando la función LoadFromAPI. Esta función obtiene datos de la [PokéAPI](https://pokeapi.co/) y los carga en la base de datos.

## Cargar Datos desde PokéAPI

La función LoadFromAPI obtiene tipos de Pokémon y detalles de Pokémon de la PokéAPI, poblándolos en las respectivas tablas de la base de datos si están vacías.

## Endpoints

### Obtener Tipos
- **Método HTTP:** GET
- **Ruta:** `/types`
- **Descripción:** Obtiene una lista de tipos de Pokémon desde la base de datos.

### Obtener Detalles de Pokémon por ID
- **Método HTTP:** GET
- **Ruta:** `/{id}`
- **Descripción:** Obtiene detalles de un Pokémon basado en su ID único.

### Filtrar Pokémon
- **Método HTTP:** GET
- **Ruta:** `/`
- **Descripción:** Filtra Pokémon basados en varios criterios como nombre, tipos y estadísticas.

## Notas Adicionales

- El proyecto utiliza async/await para operaciones asíncronas.
- Se implementa manejo de errores para manejar excepciones de manera elegante.
- Se pueden aplicar filtros para reducir los resultados de búsqueda de Pokémon.

## Tecnologías Utilizadas

- C#
- Entity Framework
- ASP.NET Core
- [PokéAPI](https://pokeapi.co/)

## Comenzar

Para comenzar con este proyecto, asegúrese de tener las dependencias necesarias instaladas y siga las instrucciones proporcionadas en el archivo README del proyecto.

---

# Pokedex Kanto with Framework Project

This project utilizes Entity Framework to create a database for Pokémon and their types, establishing a many-to-many relationship between them. The initial step involves populating the database by utilizing the LoadFromAPI function. This function fetches data from the PokéAPI (https://pokeapi.co/) and loads it into the database.

## Loading Data from PokéAPI

The LoadFromAPI function fetches Pokémon types and Pokémon details from the PokéAPI, populating the respective tables in the database if they are empty.

## Endpoints

### Get Types
- **HTTP Method:** GET
- **Route:** `/types`
- **Description:** Retrieves a list of Pokémon types from the database.

### Get Pokémon Details by ID
- **HTTP Method:** GET
- **Route:** `/{id}`
- **Description:** Retrieves details of a Pokémon based on its unique ID.

### Filter Pokémon
- **HTTP Method:** GET
- **Route:** `/`
- **Description:** Filters Pokémon based on various criteria such as name, types, and stats.

## Additional Notes

- The project utilizes async/await for asynchronous operations.
- Error handling is implemented to handle exceptions gracefully.
- Filters can be applied to narrow down Pokémon search results.

## Technologies Used

- C#
- Entity Framework
- ASP.NET Core
- [PokéAPI](https://pokeapi.co/)

## Getting Started

To get started with this project, ensure you have the necessary dependencies installed and follow the instructions provided in the project's README file.

