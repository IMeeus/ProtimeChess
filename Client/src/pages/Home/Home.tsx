import { useNavigate } from "react-router-dom";

function Home() {
    const navigate = useNavigate();

    function handleStartGame() {
        navigate("/game");
    }

    return (
        <div className="vh-100 border d-flex align-items-center justify-content-center">
            <button className="btn btn-dark btn-lg" onClick={handleStartGame}>Start Game</button>
        </div>
    )
}

export default Home;