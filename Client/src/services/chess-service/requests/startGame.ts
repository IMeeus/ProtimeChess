import { ChessRequest, call } from "../utils/call";

interface StartGameResponse {
    gameId: number
}

export const startGame = async (gameId: number): Promise<StartGameResponse> => {
    const request: ChessRequest = {
        method: 'PUT',
        subUrl: `/game/${gameId}/start`
    };

    return call(request);
}