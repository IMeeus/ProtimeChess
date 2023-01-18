export interface ChessRequest {
    method: "GET" | "POST" | "PUT" | "DELETE" | "PATCH",
    subUrl: string,
    body?: string,
}

export const call = async <ChessResponse>(request: ChessRequest): Promise<ChessResponse> => {
    const requestOptions = {
        method: request.method,
        header: null,
        body: request.body ?? null
    };

    const uri = process.env.REACT_APP_CHESS_API_URL + request.subUrl;
    const response = await fetch(uri, requestOptions);
    const text = await response.text();

    if (response.ok) {
        return text && JSON.parse(text);
    }

    return Promise.reject("An error occured!");
}