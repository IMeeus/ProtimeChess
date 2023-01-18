import { useNavigate } from "react-router-dom";
import { createGame, startGame } from "services/chess-service";

const Home = () => {
    const navigate = useNavigate();

    const handleCreateGame = async () => {
        const createdGame = await createGame();
        console.log(`New game with id: ${createdGame.gameId}`);

        await startGame(createdGame.gameId);

        navigate(`/game/${createdGame.gameId}`);
    }

    return (
        <div className="vh-100 border d-flex align-items-center justify-content-center">
            <button className="btn btn-dark btn-lg" onClick={handleCreateGame}>Start Game</button>
        </div>
    )
}

export default Home;