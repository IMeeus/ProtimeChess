import { Board } from "../models/Board";
import { ChessRequest, call } from "../utils/call";

interface GetBoardResponse {
    board: Board;
}

export const getBoard = async (gameId: number): Promise<GetBoardResponse> => {
    const request: ChessRequest = {
        method: 'GET',
        subUrl: `/game/${gameId}/board`
    };

    return call(request);
}