# Pokedex Kanto

## PokéAPI Entity Framework Project

This project utilizes Entity Framework to create a database for Pokémon and their types, establishing a many-to-many relationship between them. The initial step involves populating the database by utilizing the `LoadFromAPI` function. This function fetches data from the [PokéAPI](https://pokeapi.co/) and loads it into the database.

---

## Project Overview

- **Loading Data from PokéAPI:** The `LoadFromAPI` function fetches Pokémon types and Pokémon details from the PokéAPI, populating the respective tables in the database if they are empty.

