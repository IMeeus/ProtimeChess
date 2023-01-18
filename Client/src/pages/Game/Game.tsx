import Square from "components/Square";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { BoardState, getBoard } from "services/chess-service";

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
    }, [id]);

    const renderBoard = () => {
        if (!boardState) return;

        const squares = Object.keys(boardState).map((key, index) => {
            const row = parseInt(key[1]);
            const col = index % 8;

            const color = (row % 2) === (col % 2) ? 'white' : 'black';

            const piece = boardState[key];

            return <Square key={key} color={color} piece={piece} />;
        })

        return (
            <div className="d-flex flex-wrap">
                {squares}
            </div>
        )
    }

    return (
        <div className="mx-auto text-center" style={{width: '400px'}}>
            <h1 className="m-5">Game {id}</h1>
            {renderBoard()}
        </div>
    )
}

export default Game;