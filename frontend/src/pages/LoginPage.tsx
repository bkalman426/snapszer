import { useState } from "react";

export function LoginPage({ onJoin }: Readonly<{ onJoin: (id: number) => void }>) {
  const [playerName, setPlayerName] = useState("");

  const handleJoin = async () => {
    try {
      const response = await fetch("/api/player", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ playerName }),
      });
      if (!response.ok) {
        throw new Error("Failed to join the game");
      }
      const body = await response.json();
      onJoin(body.PlayerId);
    } catch (error) {
      console.error("Error:", error);
      alert("Failed to join the game.");
    }
  };

  return (
    <div>
      <h1>Name:</h1>
      <input
        type="text"
        value={playerName}
        onChange={(e) => setPlayerName(e.target.value)}
      />
      <button onClick={handleJoin}>Join</button>
    </div>
  );
}
