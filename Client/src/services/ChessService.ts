export async function startGame() {
    var requestOptions = {
        method: "POST",
        header: null,
        body: null
    };

    const result = await fetch("https://localhost:44303/api/v1/chess/startGame", requestOptions);
    console.log(result);
}