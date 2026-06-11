import {Link} from "react-router-dom";
import "../styles/Navbar.css";

function Navbar() {
    return(
        <nav className="navbar">
            <div className="logo">GameStore</div>

            <div className="navbar-links">
                <Link to="/">Games</Link>
                <Link to="/create">Create Game</Link>
            </div>
        </nav>
    );
}
export default Navbar;