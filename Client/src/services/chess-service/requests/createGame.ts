import { ChessRequest, call } from "../utils/call";

interface CreateGameResponse {
    gameId: number
}

export const createGame = async (): Promise<CreateGameResponse> => {
    const request: ChessRequest = {
        method: 'POST',
        subUrl: '/game'
    };

    return call(request);
}