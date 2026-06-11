import { Link, Routes, Route} from "react-router-dom";
import GamesList from "./pages/GamesList";
import CreateGame from "./pages/CreateGame";
import Navbar from "./components/Navbar";

function App()
{
  return(
    <>
      <Navbar />
      
      <div style={{padding: "20px" }}>
        <Routes>
          <Route path="/" element={<GamesList />} />
          <Route path="/create" element={<CreateGame />} />
        </Routes>
      </div>
    </>
  );
}
export default App;