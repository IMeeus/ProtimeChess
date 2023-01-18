// import { useNavigate } from "react-router-dom";
import { startGame } from "services/chess-service";

function Home() {
    // const navigate = useNavigate();

    async function handleStartGame() {
        await startGame();
        // navigate("/game");
    }

    return (
        <div className="vh-100 border d-flex align-items-center justify-content-center">
            <button className="btn btn-dark btn-lg" onClick={handleStartGame}>Start Game</button>
        </div>
    )
}

export default Home;