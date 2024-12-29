import "./Card.css";
import { PlayingCard } from "../types";

export function Card({card} : Readonly<{card: PlayingCard;}>){
    return <div className="playing-card">
        <p>{card.suit} {card.number}</p>
    </div>
}