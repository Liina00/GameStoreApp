import { useEffect, useState } from "react";
import { getAllGames, deleteGame, updateGame } from "../services/gamesService";
import { getAllGenres } from "../services/genresService";
import "../styles/GamesList.css";

function GamesList() {
  const [games, setGames] = useState([]);
  const [genres, setGenres] = useState([]);

  const [selectedGenre, setSelectedGenre] = useState(0);
  const [search, setSearch] = useState("");
  const [sort, setSort] = useState("title");

  const [editOpen, setEditOpen] = useState(false);
  const [currentGame, setCurrentGame] = useState(null);

  const loadGames = () => {
    getAllGames().then(setGames);
  };
  
  const loadGenres = () => { getAllGenres().then(setGenres); };

  useEffect(() => {
    loadGames();
    loadGenres();
  }, []);

  const handleDelete = async (id) => {
    await deleteGame(id);
    loadGames();
  };
  function openEditModal(game) {
    setCurrentGame(game);
    setEditOpen(true);
  };
  async function saveEdit() {
    await updateGame(currentGame.id, currentGame);
    setEditOpen(false);
    loadGames();
  }

  const filtered = games
  .filter((g) => selectedGenre === 0 ? true : g.genreId === selectedGenre)
  .filter((g) => g.title.toLowerCase().includes(search.toLowerCase()));
  
  const sorted = [...filtered].sort((a, b) => {
    if(sort=== "title") return a.title.localeCompare(b.title);
    if(sort=== "price") return a.price - b.price;
    if(sort === "year") return a.releaseYear - b.releaseYear;
    return 0;
  });
  
  return (
    <div className="panel">
      <h2>Games</h2>
      {/* filter bar*/}
      <div className="filter-bar">
        <select
          value={selectedGenre}
          onChange={(e) => setSelectedGenre(Number(e.target.value))}
        >
          <option value={0}>All Genres</option>
          {genres.map((g) => (
            <option key={g.id} value={g.id}>
              {g.name}
            </option>
          ))}
        </select>

        <input
          type="text"
          placeholder="Search games..."
          value={search}
          onChange={(e) => setSearch(e.target.value)}
        />

        <select value={sort} onChange={(e) => setSort(e.target.value)}>
          <option value="title">Sort: Title</option>
          <option value="price">Sort: Price</option>
          <option value="year">Sort: Release Year</option>
        </select>
      </div>

      {/* GRID */}
      <div className="games-grid">
        {sorted.map((game) => (
          <div key={game.id} className="game-card">
            {/*for hover popupen for description*/}
            <div className="hover-info">
              <p>{game.description}</p>
            </div>

            <h3>{game.title}</h3>
            <span className="genre">{game.genreName}</span>
            <p className="price">{game.price} €</p>
            <p className="year">{game.releaseYear}</p>

            <button className="edit-btn" onClick={() => openEditModal(game)}>
              Edit
            </button>

            <button
              className="delete-btn"
              onClick={() => handleDelete(game.id)}>
              Delete
            </button>
          </div>
        ))}
      </div>
      {/*EDIT MODAL HERE */}
      {editOpen && currentGame && (
        <div className="modal">
          <div className="modal-content">
            <h3>Edit Game</h3>

            <label>Title</label>
            <input
              type="text"
              value={currentGame.title}
              onChange={(e) =>
                setCurrentGame({ ...currentGame, title: e.target.value })
              }
            />

            <label>Description</label>
            <textarea
              value={currentGame.description}
              onChange={(e) =>
              setCurrentGame({ ...currentGame, description: e.target.value })
            }
           />

            <label>Release Year</label>
            <input
              type="number"
              value={currentGame.releaseYear}
              onChange={(e) =>
              setCurrentGame({ ...currentGame, releaseYear: e.target.value })
            }
           />

           <button className="save-btn" onClick={saveEdit}>
             Save
           </button>

           <button className="close-btn" onClick={() => setEditOpen(false)}>
             Close
           </button>
         </div>
       </div>
     )}
  </div>
);
}
export default GamesList;