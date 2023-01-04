import {
  Route, Routes, Navigate
} from "react-router-dom";
import Game from "./pages/Game/Game";
import Home from "./pages/Home/Home";

function App() {
  return (
    <Routes>
      <Route path="/" element={<Home />} />
      <Route path="/game" element={<Game />} />
      <Route path="*" element={<Navigate to="/" />}/>
    </Routes>
  );
}

export default App;