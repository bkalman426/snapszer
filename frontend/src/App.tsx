import { useState } from "react";
import "./App.css";

function App() {
  const [playerId, setPlayerId] = useState(-1);

  if (playerId === -1) return <LoginPage onJoin={setPlayerId} />;
  else
    return (
      <div className="game">
        <GamePage />
      </div>
    );
}

export default App;
import { GamePage } from "./pages/GamePage";
import "bootstrap/dist/css/bootstrap.min.css";
import { LoginPage } from "./pages/LoginPage";
