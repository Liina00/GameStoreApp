import { useState, useEffect } from "react";
import { createGame } from "../services/gamesService";//games
import { getAllGenres } from "../services/genresService";//genres
import { useNavigate } from "react-router-dom";//redirect after submit
import "../styles/CreateGame.css";

function CreateGame()
 {
  const navigate = useNavigate();//redirect afte submit
  const [title, setTitle] = useState("");
  const [price, setPrice] = useState("");//hade 0 innan, men då försviunner ej nollan, blir tex 039$
  const [description, setDescription] = useState("");
  const [releaseYear, setReleaseYear] = useState("");
  const [genreId, setGenreId] = useState(0);
  const [genres, setGenres] = useState([]);

  useEffect(() => {
    getAllGenres().then(setGenres);
  }, []);

  const handleSubmit = async (e) => {
    e.preventDefault();

    await createGame({
      title,
      price: parseFloat(price.replace(",", ".")),
      description,
      releaseYear,
      genreId,
    });
    // Reset form here
    setTitle("");
    setPrice("");
    setDescription("");
    setReleaseYear("");
    setGenreId(0);
    //here redirect to list
    navigate("/");
  };
  return (
    <div className="panel">
      <h2>Create Game</h2>

      <form className="create-form" onSubmit={handleSubmit}>
        <label>Title</label>
        <input
          type="text"
          value={title}
          onChange={(e) => setTitle(e.target.value)}
        />

        <label>Price</label>
        <input
          type="number"
          value={price}
          onChange={(e) => setPrice(e.target.value)}
          onBlur={() => {
            if(price === "") return;
            let value = price.replace(",", ".");//changing , to dot
            const num = parseFloat(value);//converting to number then formate
            if(!isNaN(num)) { setPrice(num.toFixed(2)); }//get it to 2 decimals always
          }
        }
        />

        <label>Description</label>
        <input
          type="text"
          value={description}
          onChange={(e) => setDescription(e.target.value)}
        />

        <label>Release Year</label>
        <input
          type="number"
          value={releaseYear}
          onChange={(e) => setReleaseYear(Number(e.target.value))}
        />

        <label>Genre</label>
        <select
          value={genreId}
          onChange={(e) => setGenreId(Number(e.target.value))}
        >
          <option value="0">Select Genre</option>
          {genres.map((g) => (
            <option key={g.id} value={g.id}>
              {g.name}
            </option>
          ))}
        </select>

        <button type="submit">Create</button>
      </form>
    </div>
  );
}
export default CreateGame;