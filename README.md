# GAMESTOREAPP

##### A backend application where u can manage Games, add, remove and edit

### *What the application has*
- Add *Genres*
- Add *Games* with:
  - Title
  - Desciriotion
  - Price
  - Genre
  - Release year
- View all *Games* and *Genres*
- View a specific Game or Genre by its ID
- Update Games or Genres
- Delete Games/Genres
- Data gets saved to database

## How to run the project
### Requirements
- [.NET 8 SDK] (https://dotnet.microsoft.com/download)
- [Visual Studio 2022]  includes SQL Server LocalDB. (https://visualstudio.microsoft.com/)

### Steps
1.1. Clone the repository link here → " https://github.com/Liina00/GameStoreApp.git "  ←
```bash
   git clone https://github.com/Liina00/GameStoreApp.git
   cd GameStoreApp
```
2. Apply database migrations
```bash
   dotnet ef database update
   ```
3. Run the API
```bash
   dotnet run
```
4. Open Swagger

# API Endpoints

###  Games
| Method | Endpoint | Description |
|--------|-----------|-------------|
| GET | `/api/games` | Get all *(Games)* |
| GET | `/api/games/{id}` | Get a "single" Game by ID |
| POST | `/api/games` | Add a new Game *(Title, Description, Price, GenreId, ReleaseYear)* |
| PUT | `/api/games/{id}` | Update a *Game* |
| DELETE | `/api/games/{id}` | Delete a *Game* |

###  Genres
| Method | Endpoint | Description |
|--------|-----------|-------------|
| GET | `/api/genres` | Get all *(Genres)* |
| GET | `/api/genres/{id}` | Get a "single" Genre by ID |
| POST | `/api/genres` | Add a new Genre |
| PUT | `/api/genres/{id}` | Update a *Genre* |
| DELETE | `/api/genres/{id}` | Delete a *Genre* |

## Database
- SQL Server LocalDB
- ORM: Entity Framework Core 8
- Migrations
  - InitialCreate - It creates the *Games* and *Genres* tables

## Project structure
- GameStoreAPI - Controllers + Swagger
- GameStore.Application - Commands, queries, handlers and Dtos
- GameStore.Domain - Entities
- GameStore.Infrastructure - DbContext + Repositories

## Frontend (react)
Simple react frontend to be able to create new games, delete, or update its details (price) etc.
### How to run the frontend
#### Requirements
- Node.js(v18+
- npm

### Steps
1. Open frontend folder
2.
 ``` bash
  cd frontend
```
``` bash
npm install
```
``` bash
npm run dev
```
4. Open it go to " http://localhost:5173 "

### Styling inspired by
- Leetify
