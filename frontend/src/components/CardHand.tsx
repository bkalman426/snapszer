import { Player } from "../Types";
import { Card } from "./Card";
import "./CardHand.css";

export function CardHand({ player }: Readonly<{ player: Player }>) {
  const handSize = player.hand ? player.hand.length : player.cardCount;
  const angleIncrement = 150 / (handSize - 1);
  const startAngle = -75;
  const radius = 60;
  return (
    <div className="card-hand">
      {(player.hand || Array(player.cardCount).fill(null)).map(
        (card, index) => {
          const angle = startAngle + index * angleIncrement;
          const rotate = `rotate(${angle}deg)`;
          const translate = `translate(0, -${radius}px)`;
          return (
            <div
              key={index}
              className="card-container"
              style={{
                transform: `${rotate} ${translate}`,
              }}
            >
              <Card card={card}/>
            </div>
          );
        }
      )}
      <div className="won-cards">
        {player.score > 0 && <Card card={null}/>}
        <div className="score"> Score: {player.score}</div>
      </div>
    </div>
  );
}
