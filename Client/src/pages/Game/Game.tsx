import Square from "components/Square";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { getBoard, BoardState } from "services/chess-service";

const Game = () => {
    const { id } = useParams();
    const [boardState, setBoardState] = useState<BoardState>();

    useEffect(() => {
        const loadBoard = async () => {
            const response = await getBoard(parseInt(id!)).then(res => res.board.state);
            setBoardState(response);

            console.log(response);
        }

        loadBoard();
    }, []);

    return (
        <>
            <h1>Game Page</h1>
            <Square color="black" piece='black King'></Square>
        </>
    )
}

export default Game;