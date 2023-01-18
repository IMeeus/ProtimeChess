import { Game } from "services/chess-service";

export const startGame = async (): Promise<Game> => {
    const requestOptions = {
        method: "POST",
        header: null,
        body: null
    };

    const response = await fetch("https://localhost:44303/api/v1/chess/startGame", requestOptions);
    const text = await response.text();

    if (response.ok) {
        return text && JSON.parse(text);
    }

    return Promise.reject("An error occured!");
}