import {
  Route, Routes
} from "react-router-dom";
import Game from "./pages/Game/Game";
import Home from "./pages/Home/Home";

function App() {
  return (
    <Routes>
      <Route path="/" element={<Home />} />
      <Route path="/game" element={<Game />} />
    </Routes>
  );
}

export default App;